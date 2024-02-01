using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;
	
	[SerializeField] private AudioClip shootingSFX;
	[SerializeField] private AudioClip gameOverSFX;
	[SerializeField] private AudioClip rockDestroySFX;
	[SerializeField] private AudioClip shipDestroySFX;
	
	private AudioSource audioSource;
	
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	
	
	void Start()
    {
	    audioSource = GetComponent<AudioSource>();
    }

	public void ShootingSFX()
   {
	   audioSource.PlayOneShot(shootingSFX);
   } 
	
	public void GameOverSFX()
	{
		audioSource.PlayOneShot(gameOverSFX);
	}
	
	public void RockDestroySFX()
	{
		audioSource.PlayOneShot(rockDestroySFX);
	}
	
	public void ShipDestroySFX()
	{
		audioSource.PlayOneShot(shipDestroySFX);
	}
	
}
