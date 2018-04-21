using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public delegate void ItemCollected(GameObject uibox);
    public event ItemCollected OnItemCollected;

    //i think we dont need inventory of player for now
    public List<CollectableModel> inventory = new List<CollectableModel>();

    private GameManager _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attr = collision.GetComponent<CollectableAttributes>();


        if (attr)
        {
            if (!_gm.AreSlotsFull())
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
}
