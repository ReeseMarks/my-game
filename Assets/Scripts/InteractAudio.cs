using UnityEngine;

public class InteractAudio : MonoBehaviour
{
    public AudioSource audioSource;


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
