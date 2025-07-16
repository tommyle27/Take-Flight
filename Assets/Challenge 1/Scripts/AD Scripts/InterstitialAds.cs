using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener {
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;

    private void Awake() {
        #if UNITY_IOS
                    adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
                    adUnitId = androidAdUnitId;
        #elif UNITY_EDITOR
                adUnitId = androidAdUnitId; // If you haven't switched the platform...
        #endif
    }

    public void LoadInterstitialAd() {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitialAd() {
        if (!Advertisement.isInitialized)
        {
            Debug.LogWarning("Ads not initialized yet!");
            return;
        }
        if (string.IsNullOrEmpty(adUnitId))
        {
            Debug.LogError("Ad Unit ID not set!");
            return;
        }

        Advertisement.Show(adUnitId, this);
        LoadInterstitialAd();
    }

    #region LoadCallbacks
    public void OnUnityAdsAdLoaded(string placementId) {
        Debug.Log("Interstitial Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }
    #endregion
    #region ShowCallbacks
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {
        Debug.Log("Interstitial Ad Completed");
        LoadInterstitialAd();
    }
    #endregion
}