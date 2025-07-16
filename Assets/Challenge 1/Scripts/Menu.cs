using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    // set up shit for background music
    public AudioClip backgroundMusic;
    private AudioSource backgroundMusicSource;

    private bool shouldShowAd {
        get => PlayerPrefs.GetInt("ShouldShowAd", 0) == 1;
        set => PlayerPrefs.SetInt("ShouldShowAd", value ? 1 : 0);
    }

    private int gamesPlayed {
        get => PlayerPrefs.GetInt("GamesPlayed", 0);
        set { 
            PlayerPrefs.SetInt("GamesPlayed", value);
            PlayerPrefs.Save();
        }
    }

    private void Start() {
        // Verify PlayerPrefs is working
        Debug.Log("Games Played: " + gamesPlayed);
        Debug.Log("Should show ad: " + shouldShowAd);

        backgroundMusicSource = GetComponent<AudioSource>();

        if (backgroundMusicSource != null ) {
            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        }

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.volume = 0.3f;
        backgroundMusicSource.Play();

        if (shouldShowAd && gamesPlayed % 5 == 0) {
            AdsManager.Instance.bannerAds.HideBannerAd();
            AdsManager.Instance.interstitialAds.ShowInterstitialAd();
            shouldShowAd = false; // Reset to prevent repeat ads
        }
    }


    public void OnPlayButton() {
        gamesPlayed++;

        if (gamesPlayed % 5 == 0) {
            shouldShowAd = true; // Set flag to show ad
        }

        AdsManager.Instance.bannerAds.ShowBannerAd();
        SceneManager.LoadScene(1);
    }
    public void OnCreditsButton() {
        SceneManager.LoadScene(2);
    }

}
