using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
	[SerializeField] private TMP_Text timerText;
	[SerializeField] private GameObject winPanel;
	[SerializeField] private GameObject playerGameObject;
	[SerializeField] private GameObject powerPrefab;  // Reference to the power-up prefab

	[SerializeField] private float timerDuration = 240f;  // Default timer duration in seconds
    [SerializeField] private float firstPowerSpawnTime = 20f;
    [SerializeField] private float secondPowerSpawnTime = 20f;

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
		
		InvokeRepeating("SpawnPower", firstPowerSpawnTime, secondPowerSpawnTime);
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
		Instantiate(powerPrefab, spawnPosition, Quaternion.identity);
	}


	private void ShowWinPanel()
	{
		// Activate the win panel
		winPanel.SetActive(true);
		Time.timeScale = 0;
	}
}
