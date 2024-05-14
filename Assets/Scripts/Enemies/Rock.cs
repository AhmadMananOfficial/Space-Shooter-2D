using UnityEngine;

public class Rock : MonoBehaviour
{
	private Animator animator;
    
    void Start()
    {
	    animator = GetComponent<Animator>();
    }

    
	protected void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			// Destroying enemy & player prefab
			Destruction(); 
			Player.instance.GetDamage(1); 
		}
	}
	
	
	public void Destruction()
	{
		animator.SetBool("Destroy", true); // play destroy animation of rocks.
		SoundManager.instance.RockDestroySFX();
		Destroy(gameObject, 0.25f);
	}
	
}
