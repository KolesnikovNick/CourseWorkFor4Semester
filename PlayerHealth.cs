using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 0;
    public AudioSource damageSound;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            damageSound.Play();
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    } 

    void Die()
    {
        //Game Over Screen 
        Debug.Log("Game Over!");
        SceneManager.LoadScene(2);
    }
    
    IEnumerator Death()
    {
        deathSound.Play();
        yield return new WaitForSeconds(1);
        Die();
    }
}
