using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour {


    Quaternion rotation;
    Vector3 origPos;
	// Use this for initialization
	void Start () {
        rotation = this.transform.rotation;
        origPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, origPos.z);
    }
}
