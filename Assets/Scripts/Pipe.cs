﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public GameObject Location2;
    public AudioSource WarpSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        //var Currentpos = other.gameObject.transform.position;
        var Resetpos = Location2.transform.position;
        other.gameObject.transform.position = Resetpos;
        CancelInvoke("MoveCamera");
        WarpSound.Play();
        other.gameObject.GetComponent<player>().canMove = true;

    }
}
