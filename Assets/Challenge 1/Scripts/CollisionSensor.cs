using System.Collections;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CollisionSensor : MonoBehaviour
{
    private ScoreManager scoreManager;

    public AudioClip PlaneEngineSound;
    private AudioSource PlaneAudioSource;
    public AudioClip crashSound;
    private AudioSource crashAudioSource;

    private void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        PlaneAudioSource = GetComponent<AudioSource>();
        crashAudioSource = GetComponent<AudioSource>();

        if (PlaneAudioSource != null) {
            PlaneAudioSource = gameObject.AddComponent<AudioSource>();
        }

        PlaneAudioSource.clip = PlaneEngineSound;
        PlaneAudioSource.loop = true;
        PlaneAudioSource.Play();
        PlaneAudioSource.volume = 0.35f;
        PlaneAudioSource.pitch = 0.25f;

        if (crashAudioSource != null) {
            crashAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Wall")) {
            Time.timeScale = 0.0f;

            PlaneAudioSource?.Stop();
            
            if (crashSound != null) {
                crashAudioSource.ignoreListenerPause = true; // Ensures sound plays even when paused

                crashAudioSource.PlayOneShot(crashSound);
                // Wait for sound to finish before loading scene
                StartCoroutine(LoadSceneAfterSound(crashSound.length));
            } else {
                // If no sound, load immediately
                Time.timeScale = 1f; // Unpause before scene change
                SceneManager.LoadScene(0);
                scoreManager.ScoreReset();
            }
        }
    }

    // Coroutine to delay scene load
    private IEnumerator LoadSceneAfterSound(float delay) {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < startTime + delay) {
            yield return null; // Wait using realtime instead of scaled time
        }

        Time.timeScale = 1f; // Unpause before scene change

        SceneManager.LoadScene(0);
        scoreManager.ScoreReset();
    }
}