using UnityEngine;

public class PlayerInteractAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SadCoin"))
        {
            audioSource.Play();
            Debug.Log("Sad Coin sound played");
        }
    }
}
