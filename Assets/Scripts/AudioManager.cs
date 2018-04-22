using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public AudioClip succesPlacedBox;
    public AudioClip failerPlacedBox;
    public AudioClip jump;
    public AudioClip pickingbox;
    public AudioClip pizzadelivered;
    public AudioClip walk;


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
