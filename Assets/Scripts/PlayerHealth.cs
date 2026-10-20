using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 999;
    public int health = 100;
    public int lives = 2;
    public GameObject deathPanel;
    private bool gameOver = false;

    //Game Text
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI livesText;

    public void TakeDamage(int damage)
    {
        if(this.health > 0)
        {
            health -= damage;
            UpdateHealthHud();
            Debug.LogFormat(this.health + " health remaining");

            if(health <= 0)
            {
                Debug.LogFormat("dead");
                LoseLife();
            }
        }
    }

    public void LoseLife()
    {
        lives--;
        if(lives > 0)
        {
            health = maxHealth;
        }
        else
        {
            gameOver = true;
        }

        UpdateHealthHud();

        if(gameOver)
        {
            Debug.LogFormat("Game Over");
            deathPanel.SetActive(true);
            return;
        }

        Debug.LogFormat(this.lives + " lives remaining");
    }
    public void UpdateHealthHud()
    {
        healthText.text = "Health: " + health;
        livesText.text = "Lives: " + lives;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }

    private void Start()
    {
        UpdateHealthHud();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }


}
