using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float rotationSpeed;
    private Vector3 velocity;
    public float gravity = 9.8f;
    private bool isGround; //땅에 있는지 확인

    private void Awake()
    {

    }

    private void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }
    private void Update()
    {
        isGround = cc.isGrounded;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float MoveDir = Input.GetAxis("Vertical");
        float TurnDir = Input.GetAxis("Horizontal");

        Move(MoveDir);
        Turn(TurnDir);

        velocity.y += gravity * Time.deltaTime;

        //cc.Move(velocity * Time.deltaTime);
    }

    private void Move(float dir)
    {
        Vector3 moveDirection = transform.forward * dir * moveSpeed * Time.deltaTime;
        cc.Move(moveDirection);
        //velocity.x = moveDirection.x;
        //velocity.y = moveDirection.y;
    }

    private void Turn(float angle)
    {
        transform.Rotate(0, angle * rotationSpeed, 0);
    }
}
