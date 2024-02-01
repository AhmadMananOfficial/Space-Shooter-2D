using UnityEngine;

/// This script moves the attached object along the Y-axis with the defined speed

public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
   [SerializeField] private float speed;
    
	[SerializeField] private Vector3 bulletDirection;


	void Start()
	{
		Destroy(gameObject, 7f);
	}

    //moving the object with the defined speed
   void Update()
   {
	   transform.Translate(bulletDirection * speed * Time.deltaTime); 
   }
}
