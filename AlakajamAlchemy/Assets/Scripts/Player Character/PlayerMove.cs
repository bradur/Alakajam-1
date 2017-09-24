// Date   : 23.09.2017 00:31
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    private Vector3 direction;
    //private Rigidbody rigidBody;
    private Rigidbody2D rigidBody;

    [Range(0.2f, 200f)]
    [SerializeField]
    private float forwardSpeed = 1f;

    [Range(0.2f, 200f)]
    [SerializeField]
    private float sprintSpeed = 1f;

    /*
    [Range(0.2f, 200f)]
    [SerializeField]
    private float strafeSpeed = 1f;*/


    [Range(0.2f, 200f)]
    [SerializeField]
    private float backwardSpeed = 1f;

    private Animator animator;

    private void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");

        /*
        if (horizontalAxis > 0)
        {
            rigidBody.AddForce(transform.right * strafeSpeed, ForceMode2D.Force);
        }
        else if (horizontalAxis < 0)
        {
            rigidBody.AddForce(-transform.right * strafeSpeed, ForceMode2D.Force);
        }*/

        float verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis > 0)
        {
            animator.SetBool("Moving", true);
            rigidBody.AddForce(transform.up * forwardSpeed, ForceMode2D.Force);
        }
        else if (verticalAxis < 0)
        {
            rigidBody.AddForce(-transform.up * backwardSpeed, ForceMode2D.Force);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

    }
}
