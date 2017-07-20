using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTaken : MonoBehaviour {

    public Text ScoreText;
    private int ScoreNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ScoreNumber = PlayerPrefs.GetInt("Score");
        ScoreText.text = "Total Coins Collected: " + ScoreNumber + " / 7";
	}
}
