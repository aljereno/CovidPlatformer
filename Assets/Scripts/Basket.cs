using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Enables uGUI features

public class Basket : MonoBehaviour
{

    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start() {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }    

    // Update is called once per frame
    void Update()
    {
        //Gets mouse input
        Vector3 mousePos2D = Input.mousePosition;

        //Z position tells how far to push mouse
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert 2d into 3d game worl spacing
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move x position of basket based on mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    //Catching apples
    void OnCollisionEnter (Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple"){
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if(score > HighScore.score){
                HighScore.score = score;
            }
        }
    }
}
