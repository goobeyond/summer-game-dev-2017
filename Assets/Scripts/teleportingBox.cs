using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportingBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("teleport hit " + collision.gameObject.name);
        
        var currentPosition = collision.gameObject.transform.position;
        Debug.Log(currentPosition);
        var newPosition = new Vector3(currentPosition.x + 10, currentPosition.y + 10, currentPosition.z);
        Debug.Log("new position " + newPosition);
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.transform.position = newPosition;
        }
        
    }
}
