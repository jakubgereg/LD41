using System;
using UnityEngine;

public class Tutorial_2 : MonoBehaviour
{

    public TextMesh text;

    private void Start()
    {
        var gm = FindObjectOfType<GameManager>();
        gm.OnGameModeChange += Tutorial_OnGameModeChange;

        var zone = FindObjectOfType<ZoneDetect>();
        zone.OnEndZoneReached += Gm_OnEndZoneReached;


    }

    private void Gm_OnEndZoneReached(GameObject zone)
    {
        text.text = "Well done! Now get back to your car";
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > 20f)
        {
            NeedToRestartText();
        }
    }

    private void NeedToRestartText()
    {
        text.text = "Need to restart? Press 'R'\n";
    }

    private void Tutorial_OnGameModeChange(GameModes gm)
    {
        if (gm.Equals(GameModes.BUILDING))
        {
            text.text = "Here you can drag and drop the cube\nIt will help you to jump higher!\n";
        }
        else
        {
            text.text = "Pick the cube and Press 'Q'";
        }
    }
}
