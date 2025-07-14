using System.Collections.Generic;
using UnityEngine;

public class TriggerSensor : MonoBehaviour {

    //public GameObject Obstacle;
    public List<GameObject> ObstaclePrefabs;
    // have a list of colours, we want to assign the walls different colors randomly
    public List<Color> Colors;

    // score managing shit
    private ScoreManager scoreManager;

    // sound shit
    public AudioClip pointSound;
    private AudioSource pointSoundSource;
    private void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        pointSoundSource = GetComponent<AudioSource>();

        // If there isn't one, add it automatically
        if (pointSoundSource == null) {
            pointSoundSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SpawnWall")) {
            // track last wall that was used, before spawning new mf wall check if they are same, if true spawn different wall
            int randomIndex;
            randomIndex = Random.Range(0, ObstaclePrefabs.Count);
            GameObject currentObstacle = ObstaclePrefabs[randomIndex];
            
            // spawn in that wall
            GameObject newWall = Instantiate(currentObstacle, new Vector3(-3, -4, 300), new Quaternion(1f, 0f, 0f, 1f));
  
            // assign a randmon color to the wall now
            Color randomColor = Colors[Random.Range(0, Colors.Count)];
            Renderer renderObstacle = newWall.GetComponent<Renderer>();

            if (renderObstacle != null) {
                // instead of using a shared material for all instances, create a new material instance and use for current wall
                Material currentMaterial = new Material(renderObstacle.sharedMaterial);
                currentMaterial.color = randomColor;
                renderObstacle.material = currentMaterial;
            }
        }

        if (other.CompareTag("DestroyWall")) {
            if (scoreManager != null) {
                scoreManager.AddScore(1);
            } else {
                Debug.LogWarning("ScoreManger not Found!!!");
            }

            // Play sound FIRST
            if (pointSound != null) {
                pointSoundSource.PlayOneShot(pointSound);
                // Optional: Delay destruction slightly to ensure sound plays
                Destroy(gameObject, pointSound.length); // Destroy after sound finishes
            } else {
                Debug.LogWarning("No Point Sound Assigned");
                Destroy(gameObject); // Destroy immediately if no sound
            }
        }
    }
}
