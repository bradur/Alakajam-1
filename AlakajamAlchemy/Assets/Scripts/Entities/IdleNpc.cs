// Date   : 23.09.2017 15:38
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class IdleNpc : MonoBehaviour {

    private Animator animator;

    private Rigidbody2D rigidBody;

    [SerializeField]
    private float moveIntervalMax = 25f;
    [SerializeField]
    private float moveIntervalMin = 4f;
    private float moveTimer = 0f;

    private float moveInterval;

    private bool idle = true;

    [SerializeField]
    [Range(0.2f, 50f)]
    private float speed;

    [SerializeField]
    [Range(0.2f, 5f)]
    private float impulseSpeed;

    private bool moving = false;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RandomMove();
    }

    void StartMoving ()
    {
        ForceMode2D randomForce = Random.value > 0.5f ? ForceMode2D.Impulse : ForceMode2D.Force;
        float movespeed = randomForce == ForceMode2D.Impulse ? impulseSpeed : speed;
        rigidBody.AddForce(transform.up * movespeed, randomForce);
        animator.SetTrigger("Move");
        moving = true;
    }

    void StopMoving ()
    {
        animator.SetTrigger("StopMoving");
        moving = false;
        idle = true;
    }

    void RandomizeDirection ()
    {
        Vector3 randomDirection = new Vector3(0f, 0f, transform.localEulerAngles.z + Random.Range(10f, 45f));
        transform.Rotate(randomDirection);
    }

    void RandomMove ()
    {
        idle = false;
        RandomizeDirection();
        StartMoving();
        moveTimer = 0f;
        moveInterval = Random.Range(moveIntervalMin, moveIntervalMax);
    }
    void Update () {
        if (idle)
        {
            moveTimer += Time.deltaTime;
            if (moveTimer >= moveInterval)
            {
                RandomMove();
            }
        }
        if (rigidBody.velocity.magnitude < 0.2f && moving && !idle)
        {
            StopMoving();
        }
    }
}
