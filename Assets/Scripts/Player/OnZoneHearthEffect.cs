using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnZoneHearthEffect : MonoBehaviour {

    public float hearthDuration;
    public float hearthSpeed;

    private void Update()
    {
        transform.position += hearthSpeed * Vector3.up * Time.deltaTime;
        hearthDuration -= Time.deltaTime;
        if (hearthDuration <= 0)
            Destroy(gameObject);
    }
}
