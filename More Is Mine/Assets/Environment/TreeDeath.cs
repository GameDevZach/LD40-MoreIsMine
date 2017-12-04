using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeath : MonoBehaviour {
    float lifeTime;

	// Use this for initialization
	void Start () {
        lifeTime = 7.5f;
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}

    void FixedUpdate ()
    {
        transform.Translate(new Vector3(0.0f, 0.0f, -0.05f));
    }
}
