using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
	[SerializeField] private float backgroundSpeed = 1.0f;
	
	private new MeshRenderer renderer;	
     
    void Start()
    {
   	    renderer = GetComponent<MeshRenderer>();   
    }

    
    void Update()
    {
	    renderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
	    
}