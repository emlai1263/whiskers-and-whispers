using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerBulletDug : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public float decreasePerMinute;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;

		healthBar.SetMaxHealth(maxHealth);

		// spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= 0){
			SceneManager.LoadSceneAsync("BulletGameDug");
		}
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if(currentHealth > 100){
			currentHealth = 100;
		}
		if(currentHealth < 0){
			currentHealth = 0;
		}
		healthBar.SetHealth(currentHealth);
	}
	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("bullet")) // Check if collided with player
        {
            TakeDamage(7);
        }
    }
}