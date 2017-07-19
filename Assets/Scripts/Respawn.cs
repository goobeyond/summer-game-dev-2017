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
        //Debug.Log("hit");
        //var Currentpos = other.gameObject.transform.position;
        var Resetpos = new Vector3(0, 10, 0);
        other.gameObject.transform.position = Resetpos;
        var currentDir = other.gameObject.GetComponent<player>().direction;
        if (currentDir != 1)
        {
            other.gameObject.GetComponent<player>().direction = 1;
        }
    }
}
