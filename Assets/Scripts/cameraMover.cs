using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour {

    Camera[] cameras;
    GameObject player;
    int counter;

    // Use this for initialization
    void Start () {
		cameras = FindObjectsOfType<Camera>();

        
    }

    void MoveCamera()
    {
        var oldposcamera = cameras[1].transform.position;
        var oldposplayer = player.transform.position;
        oldposcamera.x += 0.1f;
        oldposplayer.x += 0.05f;
        cameras[1].transform.position = oldposcamera;
        player.transform.position = oldposplayer;
        counter++;
        if(counter > 500)
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            CancelInvoke("MoveCamera");
        }
        Debug.Log(counter);
    }   

    private void OnTriggerEnter(Collider other)
    {
        cameras[0].enabled = false;
        cameras[1].enabled = true;
        player = other.gameObject;
        InvokeRepeating("MoveCamera", 0, 0.01f);
    }
}
