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

    [SerializeField]
    [Range(0.2f, 5f)]
    private float impulseFleeSpeed = 0.5f;

    private bool moving = false;

    private Bandit bandit;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mob = GetComponent<Mob>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        RandomMove();
        bandit = GetComponent<Bandit>();
    }

    void StartMoving (ForceMode2D forceMode, float moveSpeed)
    {
        Moving(forceMode, moveSpeed);
    }

    void StartMoving()
    {
        ForceMode2D forceMode = Random.value > 0.5f ? ForceMode2D.Impulse : ForceMode2D.Force;
        float moveSpeed = forceMode == ForceMode2D.Impulse ? impulseSpeed : speed;
        Moving(forceMode, moveSpeed);
    }

    void Moving (ForceMode2D mode, float moveSpeed)
    {
        rigidBody.AddForce(transform.up * moveSpeed, mode);
        animator.SetTrigger("Move");
        moving = true;
    }

    void StopMoving ()
    {
        animator.SetTrigger("StopMoving");
        moving = false;
        idle = true;
    }

    private Mob mob;
    private GameObject playerObject;

    void RandomizeDirection ()
    {
        if (mob != null && mob.IsAngry())
        {
            transform.up = ((Vector2)playerObject.transform.position - (Vector2)transform.position).normalized;
            if (bandit != null)
            {
                bandit.Shoot();
            }
        } else {
            Vector3 randomDirection = new Vector3(0f, 0f, transform.localEulerAngles.z + Random.Range(10f, 45f));
            transform.Rotate(randomDirection);
        }
    }

    public void RandomMove ()
    {
        RandomizeDirection();
        Move();
    }

    public void Flee (Vector2 from)
    {
        transform.up = -(from - (Vector2)transform.position).normalized;
        idle = false;
        moveTimer = 0f;
        moveInterval = Random.Range(moveIntervalMin, moveIntervalMax);
        StartMoving(ForceMode2D.Impulse, impulseFleeSpeed);
    }

    void Move()
    {
        idle = false;
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
