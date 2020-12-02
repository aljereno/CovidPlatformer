using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f; 
    //Static and as such is shared among all instances of classes
    //Does not appear in inspector even though public

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottomY){ //Checker to see if its out of bounds of screen view
            Destroy(this.gameObject); //Kills the object
            //this references current instance of C# class where it is called and not the gameobject
            
            //Grabs instance of applepicker class
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Calls the AppleDestroyed function within the class
            apScript.AppleDestroyed();
        }
    }
}
