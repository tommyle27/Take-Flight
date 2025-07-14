using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;
    private static uint score = 0;
    private static uint highscore = 0;

    public Text CurrentScoreText;
    public Text HighscoreText;

    private void Awake() => Instance = this;

    private void Start() {
        highscore = (uint)PlayerPrefs.GetInt("highscore", 0);
        CurrentScoreText.text = "SCORE: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddScore(uint amount) {
        // count the current score and display that shit
        score += amount;
        CurrentScoreText.text = "SCORE: " + score.ToString();
        Debug.Log("Score: " + score);

        if (highscore < score) { 
            PlayerPrefs.SetInt("highscore", ((int)score));
        }
    }
   
    public void ScoreReset() {
        score = 0;
    }
}
