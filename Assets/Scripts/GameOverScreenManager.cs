using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class GameOverScreenManager : MonoBehaviour {
	public int score;
	public int highscore;
	public Text gameOverText;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		score = GameOverScoreManager.score;
		string highscorestring = GameOverScoreManager.highscorestring;
		Debug.Log("Highscorestring"+highscorestring);
		highscore = PlayerPrefs.GetInt (highscorestring, highscore);
		gameOverText.text += score.ToString() + "\nHigh Score: " + highscore.ToString();
	}

    public void GoToMenu () {
        SceneManager.LoadScene ("MainMenu");
    }
	public void RestartGame () {
        SceneManager.LoadScene (GameOverScoreManager.scene);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}