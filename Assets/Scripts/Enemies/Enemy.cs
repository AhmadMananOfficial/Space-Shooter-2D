using UnityEngine;

/// This script defines 'Enemy's' health and behavior. 

public class Enemy : MonoBehaviour {

    [Tooltip("Health points in integer")]
    [SerializeField] private int health;

    [Tooltip("Enemy's projectile prefab")]
    [SerializeField] private GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    [SerializeField] private GameObject destructionVFX;
    [SerializeField] private GameObject hitEffect;
    
	 [SerializeField] private float shotTime = 1.0f; //max and min time for shooting from the beginning of the path
   
	 private AudioSource audioSource;
	 [SerializeField] private AudioClip shootingSFX;
	
	
    private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	    InvokeRepeating("ActivateShooting", 1.0f, shotTime);
    }

    //coroutine making a shot
    void ActivateShooting() 
    {
	    Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);
	    audioSource.PlayOneShot(shootingSFX);
	    
    }

    //method of getting damage for the 'Enemy'
	public void GetDamage(int damage) 
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
    }    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
	        Destruction(); // Destroy enemy
	        Player.instance.GetDamage(1); // Give damage to player.
        }
    }

    //method of destroying the 'Enemy'
    void Destruction()                           
	{   
		SoundManager.instance.ShipDestroySFX();     
	    Instantiate(destructionVFX, transform.position, Quaternion.identity);  
		Destroy(gameObject);
    }
}
