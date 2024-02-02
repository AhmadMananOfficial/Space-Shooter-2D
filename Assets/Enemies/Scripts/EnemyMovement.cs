using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[Tooltip("Speed at which enemies move towards the x-axis")]
	[SerializeField] private float enemySpeed = 5f; 
	private Rigidbody2D rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update()
	{
		// Move the enemy on the negative x-axis
		rb.velocity = new Vector2(-enemySpeed, 0);
		// Check if the enemy is out of bounds and destroy it
		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}

}
