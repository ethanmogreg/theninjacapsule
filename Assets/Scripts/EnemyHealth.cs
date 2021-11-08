using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            currentHealth -= damage;
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
          Destroy(gameObject);
        }
    }
}
