using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateWoodText : MonoBehaviour {
    Text myText;
    float waitASec;
    int totalTrees;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        waitASec = 1.0f;
        totalTrees = 1000;
	}
	
	// Update is called once per frame
	void Update () {
        if (waitASec > 0)
        {
            waitASec -= Time.deltaTime;
            if(waitASec <= 0)
            {
                totalTrees = PlayerPrefs.GetInt("totalTrees");
            }
        }
   
        
	}

    void FixedUpdate ()
    {
        int findWood =  PlayerPrefs.GetInt("curWood");
        int difWood = totalTrees - findWood;

        if (difWood < 10)
        {
            myText.text = "Air: " + difWood.ToString();
        }
        else
        {

            myText.text = "Wood: " + findWood.ToString();
        }
    }
}
