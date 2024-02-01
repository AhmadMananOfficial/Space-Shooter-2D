using UnityEngine;

public class PersistentObject : MonoBehaviour
{
	private static PersistentObject _instance;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}
}

