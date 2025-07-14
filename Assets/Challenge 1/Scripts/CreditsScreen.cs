using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour {
    public void OnExitButton() {
        SceneManager.LoadScene(0);
    }
}
