using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        //Text[] inputs = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        //inputs[0].text = "Text here";
    }

    void Update()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));
        
        //if (controller.isGrounded)
        //{
            
        //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //    moveDirection = transform.TransformDirection(moveDirection);
        //    moveDirection *= speed;
        //    if (Input.GetButton("Jump"))
        //        moveDirection.y = jumpSpeed;
        //}
        //moveDirection.y -= gravity * Time.deltaTime;
        //controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 1 * jumpSpeed, 0));
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("collided in player");
    //}

    //void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
    //}
}
