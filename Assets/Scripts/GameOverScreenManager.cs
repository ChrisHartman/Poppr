using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreenManager : MonoBehaviour {
	public int score;
	public int highscore;
	public Text gameOverText;
	// Use this for initialization
	void Start () {
		score = GameOverScoreManager.score;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
//		Debug.Log(highscore);
		gameOverText.text += score.ToString() + "\nHigh Score: " + highscore.ToString();
	}

    public void GoToMenu () {
        SceneManager.LoadScene ("MainMenu");
    }
	public void RestartGame () {
        SceneManager.LoadScene ("Main");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
