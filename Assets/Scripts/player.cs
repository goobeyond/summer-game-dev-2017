using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class player : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Rigidbody rb;
    Text playerSays;
    bool isGrounded;
    VignetteAndChromaticAberration CameraEffect;
    float buildUp;
    public int Score;
    public Text ScoreBoard;
    public float airSpeed;

    private bool TextIsSaid = false;
    private float Counter;
    public bool canMove = true;
    public int direction = -1;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerSays = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        CameraEffect = GetComponentInChildren<Camera>().GetComponent<VignetteAndChromaticAberration>();
    }

    void Update()
    {
        if (!isGrounded & canMove)
        {
            Debug.Log(rb.velocity.sqrMagnitude);
            //airSpeed = Input.GetAxis("Horizontal") * speed * 2;
            if (rb.velocity.sqrMagnitude < airSpeed)
            {
                rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed * 2, 0, 0));
            }
            
        }
            

        buildUp += 0.5f * Time.deltaTime;
        CameraEffect.intensity = Mathf.Lerp(1.0f, 0.0f, buildUp);

        if (TextIsSaid == true)
        {
            Counter += 1 * Time.deltaTime;
            if (Counter > 3)
            {
                TextIsSaid = false;
                Counter = 0;
                playerSays.text = null;
            }
        }
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

        ScoreBoard.text = Score + " " + "/ 7 Coins Collected";
        PlayerPrefs.SetInt("Score", Score);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = (collision.gameObject.name == "floor") ? true : false;

        //Debug.Log("grounded "+ isGrounded);

        if (isGrounded & canMove)
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * direction * speed, 0, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.UpArrow))
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
        rb.AddForce(new Vector3(0, 10 * jumpSpeed, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        SayName(collision.gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        SayName(other.gameObject);
    }


    void SayName(GameObject whatWasHit)
    {
        if (whatWasHit.name != "floor")
        {
            playerSays.text = whatWasHit.name;
            TextIsSaid = true;
            Counter = 0;
        }
    }
    //void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
    //}
}
