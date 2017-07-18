using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log("hey");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        other.transform = new Vector3(0, 0, 0);
    }
}
