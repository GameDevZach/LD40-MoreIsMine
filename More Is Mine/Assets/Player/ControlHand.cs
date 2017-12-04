using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ControlHand : MonoBehaviour {

    Animation myClips;
    int totalTrees;
    float rotDebt;

    public GameObject doomInst;
    public Light sun;
    public GameObject myController;
    FirstPersonController playerScript;


	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("curWood", 0);
        myClips = GetComponent<Animation>();
        Debug.Log("Started");
        totalTrees = GameObject.FindGameObjectsWithTag("Tree").Length;
        PlayerPrefs.SetInt("totalTrees", totalTrees);
        //Skybox.material;
        playerScript = myController.GetComponent<FirstPersonController>();
        rotDebt = 0;

        myClips["Slash"].speed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !myClips.isPlaying)
        {
            Debug.Log("Begin Chop");
            BeginChop();

        }
        
        if (rotDebt > 0)
        {
            rotDebt -= Time.deltaTime;
            sun.transform.Rotate(new Vector3(-Time.deltaTime, 0f, 0f));
        }
	}

    void BeginChop()
    {
        myClips.Play();
    }

    void ActualTreeChop()
    {
        Debug.Log("Good, tree is chopping from animation");
        RaycastHit getTree;
        Ray laser = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));

        if (Physics.Raycast(laser, out getTree,0.8f))
        {
            if (getTree.collider.gameObject.tag == "Tree")
            {
                Debug.Log("Hit a tree! Good jorb!");
                PlayerPrefs.SetInt("curWood", PlayerPrefs.GetInt("curWood") + 1);
                totalTrees -= 1;
                GameObject temp = Instantiate(doomInst);
                temp.transform.position = getTree.collider.transform.position;
                Destroy(getTree.collider.gameObject);
                rotDebt += 1.53f;

                if(totalTrees < 10)
                {
                    playerScript.speedDecay = 0.25f + totalTrees * (7.5f / 100f);
                    if(totalTrees <= 0)
                    {
                        playerScript.speedDecay = 0f;
                    }
                }
            }
        }
    }
}
