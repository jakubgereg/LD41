using UnityEngine;

public class Tutorial_1 : MonoBehaviour
{

    public TextMesh text;

    private void Start()
    {
        var zone = FindObjectOfType<ZoneDetect>();
        zone.OnEndZoneReached += Gm_OnEndZoneReached;

    }

    private void Gm_OnEndZoneReached(GameObject zone)
    {
        text.text = "Now get back to your car! Next delivery awaits!";
    }


}
