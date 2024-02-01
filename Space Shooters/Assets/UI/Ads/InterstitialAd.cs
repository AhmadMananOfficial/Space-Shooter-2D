using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	[SerializeField] string _androidAdUnitId = "Interstitial_Android";
	[SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
	public string _adUnitId;
	
	public SceneController sceneController; 

	void Awake()
	{
		// Get the Ad Unit ID for the current platform:
		_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnitId : _androidAdUnitId;
	}

	// Load content to the Ad Unit:
	public void LoadAd()
	{
		// IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
		Debug.Log("Loading Ad: " + _adUnitId);
		Advertisement.Load(_adUnitId, this);
	}

	// Show the loaded content in the Ad Unit:
	public void ShowAd()
	{
		// Note that if the ad content wasn't previously loaded, this method will fail
		Debug.Log("Showing Ad: " + _adUnitId);
		Advertisement.Show(_adUnitId, this);
	}

	
	public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
	{
		if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
		{
			// Ad was successfully completed, restart the game
			sceneController.RestartGame();
		}
		else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
		{
			// if player pressed skipped or close button
			sceneController.RestartGame();
		}
	}


	// Implement Show Listener interface methods:
	public void OnUnityAdsShowStart(string adUnitId) { }

	public void OnUnityAdsShowClick(string adUnitId) { }
	
	// Implement Load Listener interface methods:
	public void OnUnityAdsAdLoaded(string adUnitId) { }

	public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
	{
		Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
		// Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
	}

	public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
	{
		Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
		// Optionally execute code if the Ad Unit fails to show, such as loading another ad.
	}
}
