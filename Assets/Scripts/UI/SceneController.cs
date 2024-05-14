using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

	[SerializeField] private GameObject pausedPanel;
	[SerializeField] private Animator animator;
	
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void PlayGame()
	{
		LoadScene("Game"); // Game is the name of Level 01 scene name 
		FadeToLevel("Game");
	}

	public void Settings()
	{
		// Implement settings functionality here
	}

	public void PauseGame()
	{
		Time.timeScale = 0; 
		
		pausedPanel.SetActive(true);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		if(pausedPanel != null)
		{
			pausedPanel.SetActive(false);
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Game");
		ResumeGame();
	}

	public void MainMenu()
	{
		LoadScene("Main Menu");
		ResumeGame(); 
		FadeToLevel("Main Menu");
	}
	
	public void QuitGame()
	{
		Application.Quit(); 
	}
	
	public void FadeToLevel (string sceneName)
	{
		animator.SetTrigger("FadeOut");
	}
	
}
	

	
	
	
	

