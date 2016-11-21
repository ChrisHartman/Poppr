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
		score = GameOverScoreManager.score;
		//LeaderBoard.ReportScore(score, "1");
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		//Debug.Log(highscore);
		gameOverText.text += score.ToString() + "\nHigh Score: " + highscore.ToString();
		Debug.Log ("Reporting score " + score);
		Social.ReportScore (score, "1", success => {
		Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
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