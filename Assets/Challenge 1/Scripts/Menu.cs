using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    // set up shit for background music
    public AudioClip backgroundMusic;
    private AudioSource backgroundMusicSource;

    private void Start() {
        backgroundMusicSource = GetComponent<AudioSource>();

        if (backgroundMusicSource != null ) {
            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        }

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
        backgroundMusicSource.volume = 0.3f;
    }


    public void OnPlayButton() {
        SceneManager.LoadScene(1);
    }
    public void OnCreditsButton() {
        SceneManager.LoadScene(2);
    }

}
