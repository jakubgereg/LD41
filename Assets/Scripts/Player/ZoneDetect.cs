using UnityEngine;


//Detection which zones you already reached | because we need to go back to start
public class ZoneDetect : MonoBehaviour
{
    //do not use only for inspector
    public bool IsEndZoneReached;
    public bool IsEndOfLevelReached;

    public delegate void EndZoneReached(GameObject zone);
    public event EndZoneReached OnEndZoneReached;
    public event EndZoneReached OnEndOfLevelReached;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attr = collision.GetComponent<Zones>();
        if (attr)
        {
            if (attr.isEndZone && !IsEndOfLevelReached)
            {
                IsEndZoneReached = true;
                if (OnEndZoneReached != null)
                    OnEndZoneReached(attr.gameObject);
            }
            else
            {
                //if we are not at the end but we already reached end
                if (IsEndZoneReached)
                {
                    if (OnEndOfLevelReached != null)
                        OnEndOfLevelReached(attr.gameObject);
                }
            }

        }
    }
}
