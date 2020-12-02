using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    static public int score = 0;

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: "+score;
        //Updating player prefs if the current score is higher than the previous
        if(score > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore",score);
        } 
    }

    //Fixing the score restarting after closing the game
    //Awake is built in Monobehaviour method
    //Happens upon the first instance of this class
    void Awake(){
        if(PlayerPrefs.HasKey("HighScore")){
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
}
