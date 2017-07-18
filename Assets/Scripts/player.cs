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
    Text playerSays;
    bool isGrounded;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
       playerSays = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        
    }

    void Update()
    {
        if(!isGrounded)
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed , 0, 0));
            
            //if(this.transform.position.y > 6)
            //{
            //    Debug.Log("damping");
            //    rb.velocity = (new Vector3(Input.GetAxis("Horizontal") * speed, -5, 0));
            //}
        
       

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
        isGrounded = true;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 10* jumpSpeed, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player hit "+ collision.gameObject.name);
        playerSays.text = collision.gameObject.name;
    }

    //void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
    //}
}
