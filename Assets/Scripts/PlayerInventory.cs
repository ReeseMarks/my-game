using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public HudManager hudManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Heavy"))
        {
            hudManager.CollectSadGuy();
            Debug.Log("Sad Guy Collected");
        }
    }

    
}
