using UnityEngine;

/// <summary>
/// This script defines 'Player" Movement and its health.
/// </summary>

public class Player : MonoBehaviour
{
	public static Player instance;
	
	[SerializeField] private float PlayerSpeed = 10.0f;
	[Tooltip("Max & Min movement on Y-axis")]
	[SerializeField] private float MaxMovement = 4.0f;
	
	[SerializeField] private GameObject destructionFX;
	
	[Tooltip("Health points in integer")]
	[SerializeField] private int health;
	[SerializeField] private GameObject hitEffect;
	
	private Vector2 playerDirection;
	private Rigidbody2D rb;
	private Animator animator;
	
	[SerializeField] private GameObject gameOverPanel;
	
	[SerializeField] private SoundManager soundManager;


	private void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
			
	}
  
    void Start()
    {
	    rb = GetComponent<Rigidbody2D>();
	    animator = GetComponent<Animator>();
    }

  
    void Update()
    {
	    float directionY = Input.GetAxisRaw("Vertical");
	    playerDirection = new Vector2(0f, directionY).normalized;
	    
	    
    }
  
  
	void FixedUpdate()
	{
		float clampedY = Mathf.Clamp(transform.position.y, -MaxMovement, MaxMovement);
		transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

		rb.velocity = new Vector2(0f, playerDirection.y * PlayerSpeed);
	}
	
	
	//method for damage proceccing by 'Player'
	public void GetDamage(int damage) 
	{
		health -= damage;  //reducing health for damage value, if health is less than 0, starting destruction procedure
		if (health <= 0)
		{
			Destruction();
			Debug.Log(Time.timeScale);
		}	
		else
		{
			Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
		}
	}		   

	//'Player's' destruction procedure
	public void Destruction()
	{
		soundManager.GameOverSFX();
		Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
		Destroy(gameObject);
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;	
	}
	
	
}
