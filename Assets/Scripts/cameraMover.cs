using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour {

    Camera[] cameras;
    GameObject _player;
    int counter;

    // Use this for initialization
    void Start () {
		cameras = FindObjectsOfType<Camera>();

        
    }

    void MoveCamera()
    {
        var oldposcamera = cameras[1].transform.position;
        var oldposplayer = _player.transform.position;
        oldposcamera.x += 0.1f;
        oldposplayer.x += 0.05f;
        cameras[1].transform.position = oldposcamera;
        _player.transform.position = oldposplayer;
        counter++;
        if(counter > 300)
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            
            CancelInvoke("MoveCamera");
        }
        //Debug.Log(counter);
    }   

    private void OnTriggerEnter(Collider other)
    {
        cameras[0].enabled = false;
        cameras[1].enabled = true;
        _player = other.gameObject;
        _player.GetComponent<player>().canMove = false;
        InvokeRepeating("MoveCamera", 0, 0.01f);
    }
}
