using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Class Level Variables
    public GameObject collectibleObject;
    //public HudManager hudManager;
    public float boostForce = 20f;
    public float permaBoost = 10f;
    public float permaSlow = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        GameObject pickup = collectibleObject != null ? collectibleObject : gameObject;

        if (pickup.CompareTag("Coffee"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.AddForce(other.transform.forward * boostForce, ForceMode.Impulse);
            }

            Destroy(pickup);
            Debug.Log("Coffee Collected");
            return;
        }

        if (pickup.CompareTag("SadCoin"))
        {
            PlayerMovement playerMove = other.GetComponent<PlayerMovement>();
            if (playerMove != null)
            {
                playerMove.moveSpeed += permaBoost;
            }

            Destroy(pickup);
            Debug.Log("Boost Collected");
            return;
        }

        if (pickup.CompareTag("Heavy"))
        {
            PlayerMovement playerMove = other.GetComponent<PlayerMovement>();
            if (playerMove != null)
            {
                //hudManager.CollectSadGuy();
                playerMove.moveSpeed -= permaSlow;
            }
            
            Destroy(collectibleObject);
            Debug.Log("Heavy Collected");
        }
    }

}
