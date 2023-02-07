using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    [Header("Status")]

    [SerializeField] float vx;
    [SerializeField] float runSpeed;

    [SerializeField] bool groundFlag;
    [SerializeField] bool leftFlag;
    [SerializeField] bool monsterDie;

    public float destroyTimer;
    public string curState;

    Animator animator;
    Rigidbody2D rigi2D;
    SpriteRenderer sprite;
    CapsuleCollider2D capCol2D;

    Vector3 startPos;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigi2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        capCol2D = GetComponent<CapsuleCollider2D>();
    }

    public void Initialize()
    {
        vx = 0;
        runSpeed = 4;
        destroyTimer = 0;

        curState = "Idle";

        groundFlag = false;
        monsterDie = false;



        startPos = new Vector3(10.5f, -2f, 0);
        this.transform.position = startPos;

        rigi2D.constraints = RigidbodyConstraints2D.None;
        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        capCol2D.enabled = true;

        this.gameObject.SetActive(true);
    }
    void Update()
    {
        MonsterMove();

    }
    public void MonsterMove()
    {
        if (monsterDie)
        {
            destroyTimer += Time.deltaTime;

            if (destroyTimer > 2)
            {
                this.gameObject.SetActive(false);
                this.transform.position = startPos;
            }
        }
        else
        {
            if (groundFlag)
            {
                sprite.flipX = leftFlag;
                vx = runSpeed;
                rigi2D.velocity = new Vector2(vx, 0);
            }
            if (rigi2D.velocity.x >= 0)
            {
                leftFlag = false;
            }
            else
                leftFlag = true;

        }

        animator.Play(curState);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("트리거작동!");
        runSpeed = -runSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enviroment"))
        {
            groundFlag = true;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            monsterDie = true;
            curState = "Boom";
            capCol2D.enabled = false;
            rigi2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
