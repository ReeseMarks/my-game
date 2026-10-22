using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damagePerSecond = 10;
    public float damageInterval = 1f; // Damage every 1 second
    private float timer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= damageInterval)
            {
                // Try to get the player's health script and apply damage
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damagePerSecond);
                }

                // Reset the timer
                timer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset timer when the player leaves the zone
            timer = 0f;
        }
    }
}
