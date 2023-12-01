using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public HealthBar healthBar;

    [SerializeField]
    private AudioSource damageSound;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        damageSound.Play();
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }
}
