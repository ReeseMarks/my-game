using UnityEngine;

public class PlayerInteractAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Heavy"))
        {
            audioSource.Play();
            Debug.Log("Heavy sound played");
        }
    }
}
