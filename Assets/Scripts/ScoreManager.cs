using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	int score;
	public int lives;
	int highscore;
	public Text scoreText;
	public Text livesText;
	public Text gameOverText;
	public KeyCode RestartKey;
	// Use this for initialization

	void Awake() {
		Application.targetFrameRate = 60;
	}

	void Start () {
		highscore = PlayerPrefs.GetInt ("highscoreios", highscore);
		gameOverText.enabled = false;
		var ballManager = FindObjectOfType<BallManager>();
        ballManager.PoppedCorrectColor += IncrementScore;
		ballManager.PoppedIncorrectColor += LoseLife;
		score = 0;
	}

	public int LifeCount() {
		return lives;
	}
	
	
	
	/// <summary>
    /// The score has increased.
    /// </summary>
    void IncrementScore(){
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

	void LoseLife() {
		lives--;
		if (lives < 0) {
			GameOver();
		} else {
		livesText.text = "Lives: " + lives.ToString();
		}
	}

	void HighScoreCheck() {
		if (highscore < score) {
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
	}

	void GameOver() {
		FindObjectOfType<BallManager>().Die();
		HighScoreCheck();
		GameOverScoreManager.score = score;
		SceneManager.LoadScene ("GameOver");
		// gameOverText.text += score.ToString() + "\nHigh Score: " + highscore;
		// livesText.enabled = false;
		// scoreText.enabled = false;
		// gameOverText.enabled = true;
	}
}
