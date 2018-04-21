using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public delegate void ItemCollected(GameObject uibox);
    public event ItemCollected OnItemCollected;

    //i think we dont need inventory of player for now
    public List<CollectableModel> inventory = new List<CollectableModel>();

    private int invernalCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attr = collision.GetComponent<CollectableAttributes>();
        if (attr)
        {
            if (OnItemCollected != null)
            {
                OnItemCollected(attr.GenerateModel().UIBox);

            }

            //inventory.Add(attr.GenerateModel());
            Destroy(collision.gameObject);
        }
    }
}
