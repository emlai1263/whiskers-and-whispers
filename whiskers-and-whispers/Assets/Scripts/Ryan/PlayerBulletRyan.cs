using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerBulletRyan : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public float decreasePerMinute;

	public HealthBar healthBar;

    private float timer = 0f;
    private float interval = 1f; // Interval in seconds to trigger the function

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
			SceneManager.LoadSceneAsync(9);
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