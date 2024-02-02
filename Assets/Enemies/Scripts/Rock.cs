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
		if(collision.tag == "Player")
		{
			// Destroying enemy & player prefab
			Destruction(); 
			Player.instance.Destruction(); 
		}
	}
	
	
	public void Destruction()
	{
		animator.SetBool("Destroy", true);
		SoundManager.instance.RockDestroySFX();
		Destroy(gameObject, 0.25f);
		
	}
	
}
