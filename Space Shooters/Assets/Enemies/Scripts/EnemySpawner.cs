using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[Tooltip("Array to store different enemy prefabs")]
	[SerializeField] private GameObject[] enemyPrefabs;
	[Tooltip("Time interval between enemy spawns")]
	[SerializeField] private float initialSpawnInterval = 2f; 
	[Tooltip("Minimum spawn interval")]	
	[SerializeField] private float minSpawnInterval = 0.5f; 
	[Tooltip("Rate at which spawn interval decreases")]
	[SerializeField] private float spawnIntervalDecreaseRate = 0.1f; 
	[Tooltip("Max & Min Range of y-axis for enemy spawns")]
	[SerializeField] private float spawnRangeY = 4f; 
	
	private float currentSpawnInterval;


	void Start()
	{
		// Start invoking the SpawnEnemy method with the specified spawn interval
		currentSpawnInterval = initialSpawnInterval;
		InvokeRepeating("SpawnEnemy", 1f, currentSpawnInterval);
	}


	void SpawnEnemy()
	{
		// Randomly choose an index from the enemyPrefabs array
		int randomIndex = Random.Range(0, enemyPrefabs.Length);

		// Instantiate the selected enemy prefab at a random position on the y-axis
		float randomY = Random.Range(-spawnRangeY, spawnRangeY);
		Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);
		GameObject newEnemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, enemyPrefabs[randomIndex].transform.rotation);

		// Decrease the spawn interval over time
		currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseRate, minSpawnInterval);
		CancelInvoke("SpawnEnemy");
		InvokeRepeating("SpawnEnemy", currentSpawnInterval, currentSpawnInterval);
	}
	
}
