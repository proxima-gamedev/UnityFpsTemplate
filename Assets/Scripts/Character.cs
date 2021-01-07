using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float walkSpeed = 4;
    public float sprintSpeed = 6;
    public float jumpSpeed = 2;
    public float gravity = 0.04f;
    private float normalGravity;
    //public Camera Camera.main;
    private float normalSpeed;
    bool egildi;


    Vector3 moveDirection;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        normalSpeed = walkSpeed;
        normalGravity = gravity;
    }


    void Update()
    {
        Debug.Log(gravity);
        Move();

    }
    bool kos;
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (cc.isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!egildi)
                {
                    walkSpeed = sprintSpeed;
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, Time.deltaTime * 10);
                }

            }
            else
            {
                if (!egildi)
                {
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 80, Time.deltaTime * 10);
                }

                walkSpeed = normalSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpSpeed;
            }
            if (egildi)
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 70, Time.deltaTime * 10);
        }

        moveDirection.y -= gravity;
        cc.Move(moveDirection * Time.deltaTime * walkSpeed);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            cc.height = Mathf.Lerp(cc.height, 1, Time.time * 100);

            gravity = 0.1f;
            walkSpeed = 2;
            egildi = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            cc.height = Mathf.Lerp(cc.height, 2, Time.time * 100);
            gravity = normalGravity;
            walkSpeed = normalSpeed;
            egildi = false;

        }

    }
}
