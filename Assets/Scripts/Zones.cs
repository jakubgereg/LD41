using UnityEngine;

public class Zones : MonoBehaviour
{
    private void Start()
    {
        //if this zone is not end one
        if (!isEndZone)
        {
            var playerZoneDetector = FindObjectOfType<ZoneDetect>();
            playerZoneDetector.OnEndZoneReached += PlayerZoneDetector_OnEndZoneReached;
        }


    }

    //if end zone reached show arrow above start zone (end of level zone)
    private void PlayerZoneDetector_OnEndZoneReached(GameObject zone)
    {
        //GetComponent<SpriteRenderer>().enabled = true;
    }

    public bool isEndZone;
}
