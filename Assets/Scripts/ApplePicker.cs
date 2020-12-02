using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    [Header("Set in Inspector")] //Adds a header in the inpsector
    public GameObject basketPrefab;
    public int numbaskets = 3;
    public float basketBottomY = -14;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();

        //Creates three baskets
        for(int i = 0; i < numbaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            //Adds the newly created basket to a list
            basketList.Add(tBasketGO); 
        }
    }

    //public makes it accessible from other classes
    //If an apple gets destroyed it means that a user missed and get's punished by taking away one basket
    public void AppleDestroyed() {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        //Array of all existing apple gameobjects
        foreach(GameObject tGO in tAppleArray){
            Destroy(tGO);
        } //Destroys the apples

        //Gets index of the last basket in the list (topmost)
        int basketIndex = basketList.Count - 1;
        //Reference to the basket object
        GameObject tBasketGO = basketList[basketIndex];
        //Remove from list then destroy
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if(basketList.Count == 0){
            SceneManager.LoadScene("_Scene_0");
        }
    }

}
