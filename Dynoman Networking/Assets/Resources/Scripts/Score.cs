using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {



	public GUIText scoreText;
	public int scoreNum;

	// Use this for initialization
	void Start () {
		
		scoreNum = 0;
		UpdateScore();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		scoreText.text = "Score: " + scoreNum;
	}

	public void AddScore (int newScoreValue){

		scoreNum += newScoreValue;
		UpdateScore();

	}

	void UpdateScore(){

		scoreText.text = "Score: " + scoreNum;

	}
}
