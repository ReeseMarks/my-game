using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public HudManager hudManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SadCoin"))
        {
            hudManager.CollectSadGuy();
            Debug.Log("Sad Guy Collected");
        }
    }

    
}
