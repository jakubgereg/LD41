using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public delegate void ItemCollected(GameObject uibox);
    public event ItemCollected OnItemCollected;

    public AudioClip pickBlock;

    private GameManager _gm;
    private AudioSource _as;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _as = FindObjectOfType<AudioSource>();
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
                    _as.PlayOneShot(pickBlock);
                    OnItemCollected(attr.GenerateModel().UIBox);
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
