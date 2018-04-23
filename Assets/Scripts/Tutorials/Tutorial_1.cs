using UnityEngine;

public class Tutorial_1 : MonoBehaviour
{

    public TextMesh text;
    public string backToCarText;

    private void Start()
    {
        var zone = FindObjectOfType<ZoneDetect>();
        zone.OnEndZoneReached += Gm_OnEndZoneReached;

    }

    private void Gm_OnEndZoneReached(GameObject zone)
    {
        text.text = backToCarText;
    }


}
