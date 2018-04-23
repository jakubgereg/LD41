using UnityEngine;


//Detection which zones you already reached | because we need to go back to start
public class ZoneDetect : MonoBehaviour
{
    //do not use only for inspector
    public bool IsEndZoneReached;
    public bool IsEndOfLevelReached;
    public Sprite hearthSprite;
    public float hearthEffectSpeed;
    public float hearthEffectDuration;

    public delegate void EndZoneReached(GameObject zone);
    public event EndZoneReached OnEndZoneReached;
    public event EndZoneReached OnEndOfLevelReached;

    bool hearted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attr = collision.GetComponent<Zones>();
        if (attr)
        {
            if (attr.isEndZone && !IsEndOfLevelReached)
            {
                createHearthEffect();
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

    void createHearthEffect()
    {
        if (hearted)
            return;
        GameObject o = new GameObject();
        o.AddComponent<SpriteRenderer>().sprite = hearthSprite;
        OnZoneHearthEffect hearth = o.AddComponent<OnZoneHearthEffect>();
        hearth.hearthDuration = hearthEffectDuration;
        hearth.hearthSpeed = hearthEffectSpeed;

        o.transform.position = transform.position;
        hearted = true;

    }
}
