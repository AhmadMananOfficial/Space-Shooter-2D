using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
	public TMP_Text timerText;
	public GameObject winPanel;
	public GameObject playerGameObject;
	public GameObject powerPrefab;  // Reference to the power-up prefab

	public float timerDuration = 240f;  // Default timer duration in seconds

	private float startTime;
	private bool isGameOver = false;
 

	private void Start()
	{
		// Set the start time to the current time
		startTime = Time.time;
		
		// Initialize timer text to display the initial timer duration
		int initialMinutes = Mathf.FloorToInt(timerDuration / 60f);
		int initialSeconds = Mathf.FloorToInt(timerDuration % 60f);
		timerText.text = string.Format("{0:00}:{1:00}", initialMinutes, initialSeconds);
		
		InvokeRepeating("SpawnPower", 60.0f, 60.0f); // 90 & 180 seconds is power spawn time 
	}


	private void Update()
	{
		if (!isGameOver)
		{
			// Calculate the remaining time
			float remainingTime = timerDuration - (Time.time - startTime);

			// Check if time is up
			if (remainingTime <= 0.1f)
			{
				// Time's up, show win panel if player is still alive
				if (playerGameObject != null && playerGameObject.activeSelf)
				{
					ShowWinPanel();
				}
				else
				{
					// Player is not alive, game over
					Debug.Log("Game Over");
				}

				// Set the flag to avoid further updates
				isGameOver = true;
			}

			// Update the TMP text to display the timer in the format 05:00
			int minutes = Mathf.FloorToInt(remainingTime / 60f);
			int seconds = Mathf.FloorToInt(remainingTime % 60f);
			timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

		}
	}


	private void SpawnPower()
	{
		// Spawn power-up on the Y-axis
		Vector3 spawnPosition = new Vector3(10.0f, Random.Range(-4f, 4f), 0f);
		GameObject powerInstance = Instantiate(powerPrefab, spawnPosition, Quaternion.identity);

		// Destroy the power-up after 8 seconds
		Destroy(powerInstance, 8f);
		
	}


	private void ShowWinPanel()
	{
		// Activate the win panel
		winPanel.SetActive(true);
		Time.timeScale = 0;
	}
}
