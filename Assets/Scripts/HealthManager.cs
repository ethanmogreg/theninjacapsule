using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public CharacterController playerCharacter; 
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            playerCharacter.enabled = false;
            playerCharacter.transform.position = respawnPoint.position;
            playerCharacter.enabled = true;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }
}
