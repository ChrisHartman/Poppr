using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	int score;
	int lives;
	public Text scoreText;
	public Text livesText;
	public Text gameOverText;
	// Use this for initialization
	void Start () {
		gameOverText.enabled = false;
		lives = 3;
		var ballManager = FindObjectOfType<BallManager>();
        ballManager.PoppedCorrectColor += IncrementScore;
		ballManager.PoppedIncorrectColor += LoseLife;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
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

	void GameOver() {
		Time.timeScale = 0;
		gameOverText.text += score.ToString();
		livesText.enabled = false;
		scoreText.enabled = false;
		gameOverText.enabled = true;
	}
}
