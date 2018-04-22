using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public delegate void ItemCollected(GameObject uibox);
    public event ItemCollected OnItemCollected;

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
                Destroy(collision.gameObject);
            }
        }
    }
}
