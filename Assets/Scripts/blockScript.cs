using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        var currentDir = collision.gameObject.GetComponent<player>().direction;
        if (currentDir != 1)
        {
            collision.gameObject.GetComponent<player>().direction = 1;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
}
