using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Text[] inputs = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        //inputs[0].text = "Text here";
    }

    void Update()
    {

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    //void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
    //}
}
