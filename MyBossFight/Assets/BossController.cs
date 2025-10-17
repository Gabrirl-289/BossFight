using UnityEngine;

public class BossController : MonoBehaviour
{

    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent health from going below zero

        // Update health bar UI here
        // healthBarSlider.value = currentHealth / maxHealth; 

        if (currentHealth <= 0)
        {
            DefeatBoss();
        }
    }

    void DefeatBoss()
    {
        Debug.Log("Boss defeated!");
        // Implement boss death animation, scene transition, etc.
        Destroy(gameObject);
    }
}

