using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PlaySound(int clipNumber)
    {
    if (clipNumber >= 0 && clipNumber < audioClips.Length)
        {
            audioSource.PlayOneShot(audioClips[clipNumber]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boost"))
        {
            PlaySound(0);
            Debug.Log("Boost sound played");
        }
        else if(other.CompareTag("Coffee"))
        {
            PlaySound(2);
            Debug.Log("Coffee sound played");
        }
        else if(other.CompareTag("SadCoin"))
        {
            PlaySound(1);
            Debug.Log("Heavy sound played");
        }
    }
}
