using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    private float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 velocity;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        if(Input.GetKeyDown("space") && controller.isGrounded){
            Jump();
        }
    }

    void Move(){
        //get inputs
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); //this will return input value of -1, 0, 1
        float moveVertical = Input.GetAxisRaw("Vertical");

        //do maths
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward);

        //apply maths
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        //apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
    }
}
