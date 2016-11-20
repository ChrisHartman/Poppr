using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Call from inspector button
    public void ResumeGame () {
        SceneManager.LoadScene ("Main");
    }
    public void Awake () {
		Application.targetFrameRate = 60;
    }
}