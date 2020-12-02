using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    public Text scoreGT;
    private int internalScore;
    private string playerKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        internalScore = PlayerPrefs.GetInt(playerKey);
        GameObject scoreGO = GameObject.Find("HighestScore");
        scoreGT = scoreGO.GetComponent<Text>();
        if(!PlayerPrefs.HasKey(playerKey) || (PlayerPrefs.GetInt(playerKey) <= 0)){
            scoreGT.text = "No High Score yet";
        } else {
            scoreGT.text = "HighScore: " + internalScore;
        }
    }
}
