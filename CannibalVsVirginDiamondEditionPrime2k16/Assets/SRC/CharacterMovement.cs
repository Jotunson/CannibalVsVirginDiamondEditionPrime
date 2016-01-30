﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    CharacterController cC;
    Vector3 baseMove = Vector3.forward;
    Vector3 moveDir;

    float horiInput;
    float vertInput;

    bool jumpPress = false;
    float jump = 0;

    public bool rightPlayer = false;

    public float speed = 1f;
    public float jumpForce = 15f;
    public float gravity = 0.981f;

	// Use this for initialization
	void Start () {
        cC = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update() {
        if (rightPlayer)
        {
            horiInput = Input.GetAxis("Right Player Horizontal");
            vertInput = Input.GetAxis("Right Player Vertical");
            jump = Input.GetAxis("Right Player Jump");
        }
        else
        { 
            horiInput = Input.GetAxis("Left Player Horizontal");
            vertInput = Input.GetAxis("Left Player Vertical");
            jump = Input.GetAxis("Left Player Jump");
        }

        if(jump > 0)
        {
            jumpPress = true;
        }

        if (cC.isGrounded)
        {
            moveDir = (baseMove + (transform.right * horiInput + transform.forward * vertInput) / 3) * speed;
            if (jumpPress && jump <= 0)
            {
                moveDir.y = jumpForce;
                jumpPress = false;
            }
        }
        else {
            moveDir.y -= gravity;
        }

        
        cC.Move(moveDir * Time.deltaTime);
	}
}
