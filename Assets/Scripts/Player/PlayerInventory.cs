using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<CollectableModel> inventory = new List<CollectableModel>();

    private int invernalCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attr = collision.GetComponent<CollectableAttributes>();
        if (attr)
        {
            Debug.Log("im here");
            Debug.Log(attr.Type);
            inventory.Add(attr.GenerateModel());
            Destroy(collision.gameObject);
        }
    }
}
