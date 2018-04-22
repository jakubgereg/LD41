using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public AudioClip succesPlacedBox;
    public AudioClip failerPlacedBox;
    public AudioClip pizzadelivered;


    private AudioSource _as;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip c)
    {
        _as.clip = c;
        _as.Play();
    }
}
