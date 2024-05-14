using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
	[SerializeField] private int timer = 1;
	[SerializeField] private TMP_Text displayText;
    
    void Start()
	{
		Time.timeScale = 0;
	    StartCoroutine(CountdownToStart());
    }

	IEnumerator CountdownToStart()
	{
		while(timer > 0)
		{
			displayText.text = "Ready";
			
			yield return new WaitForSecondsRealtime(1f);
			
			timer--;
		}	
		displayText.text = "GO!";
		yield return new WaitForSecondsRealtime(1f);
		
		displayText.gameObject.SetActive(false);
		
		Time.timeScale = 1;
		
	}
}
