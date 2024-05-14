using UnityEngine;

/// Defines the damage and defines whether the projectile belongs to the ‘Enemy’ or to the ‘Player’,
/// whether the projectile is destroyed in the collision, or not and amount of damage.


public class Projectile : MonoBehaviour 
{

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    [SerializeField] private int damage;

    [Tooltip("Whether the projectile belongs to the ‘Enemy’ or to the ‘Player’")]
    [SerializeField] private bool enemyBullet;

    [Tooltip("Whether the projectile is destroyed in the collision, or not")]
	[SerializeField] private bool destroyedByCollision;
  

	private void OnTriggerEnter2D(Collider2D collision) //when a bullet collides with another object
    {
	    if (enemyBullet && collision.CompareTag("Player")) //if enemy bullets collide with player
        {
	        Player.instance.GetDamage(damage); 
	        
	        if (destroyedByCollision)
	        {
	        	 Destruction();
	        }
                
        }
        else if (!enemyBullet && collision.CompareTag("Enemy"))
        {
	        // Check if the collided object has either Enemy or Rock components
	        Enemy enemyComponent = collision.GetComponent<Enemy>();
	        Rock rockComponent = collision.GetComponent<Rock>();

	        if (enemyComponent != null)
	        {
		        // The collided object is an Enemy
		        enemyComponent.GetDamage(damage);
	        }

	        if (rockComponent != null)
	        {
		        // The collided object is a Rock
		        rockComponent.Destruction();
	        }

	        if (destroyedByCollision)
	        {
		        // destroy bullet
		        Destruction();
	        }
        }
    }


    void Destruction() 
    {
        Destroy(gameObject);
    }
}


