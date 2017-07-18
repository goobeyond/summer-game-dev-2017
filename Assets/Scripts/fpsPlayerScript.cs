using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsPlayerScript : MonoBehaviour {


    CharacterController control;

    // Use this for initialization
    void Start () {
        control = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        control.SimpleMove(new Vector3(0, 0, Input.GetAxis("Vertical") * 2));
    }
}
