using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    //[Header("이속")]
    //[SerializeField][Range(100f, 800f)] private float moveSpeed = 400f;
    [Header("점프값")]
    [SerializeField][Range(1f, 10f)] private float jumpValue = 4.5f;
    private bool isGrounded = true;
    private Animator anim;
    float moveX;
    private bool doubleJump = false;
    private float maxSpeed = 3f;
    private SpriteRenderer spriteRenderer;

    public GameObject spawnArea;
    public BoxCollider2D fallCollider;

    public int playerLives = 3;
    public int playerDieCnt = 0;

    private bool isStrawberryTime = false;

    private BoxCollider2D boxCollider;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fallCollider = GetComponent<BoxCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = spawnArea.transform.position;
    }
    public void Events()
    {
        EventManager.instance.AddEvent("PlayerRespawn", p =>
        {
            gameObject.transform.position = spawnArea.transform.position;
            playerLives--;
            playerDieCnt++;
        });

        EventManager.instance.AddEvent("Strawberry", p =>
        {
            StartCoroutine(Strawberry());
        });

    }

    IEnumerator Strawberry()
    {
        jumpValue = 6.5f;
        isStrawberryTime = true;
        Debug.Log("It's Strawberry Time~~~~");
        yield return new WaitForSeconds(4f);
        jumpValue = 4.5f;
        isStrawberryTime = false;
        Debug.Log("끝.");

    }
    private void Update()
    {
        Events();
        CheckGrounded();
        PlayerMove();
        EventManager.instance.SendEvent("PlayerLivesText", playerLives);
        EventManager.instance.SendEvent("LivesScore", playerDieCnt);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStrawberryTime)
            {
                if (isGrounded)
                {
                    doubleJump = true;
                    rigid.velocity = Vector2.up * jumpValue * 1.5f;
                }
                else
                {
                    if (doubleJump)
                    {
                        rigid.velocity = Vector2.up * jumpValue * 1.5f;
                        doubleJump = false;
                    }
                }
            }
            else
            {
                if (isGrounded)
                {
                    doubleJump = true;
                    rigid.velocity = Vector2.up * jumpValue;
                }
                else
                {
                    if (doubleJump)
                    {
                        rigid.velocity = Vector2.up * jumpValue;
                        doubleJump = false;
                    }
                }
            }
        }

    }

    private void PlayerMove()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(moveX * 2f, rigid.velocity.y);
        anim.SetBool("movement", moveX != 0f);
        anim.SetBool("isGrounded", isGrounded);

        if (moveX > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0f)
        {
            spriteRenderer.flipX = true;
        }

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
    }

    private void CheckGrounded() // 지면 위에 있는지 체크
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .5f, LayerMask.GetMask("Ground"));
        if (hit.collider != null) // 땅 밟앗으면
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fallCollider")
        {
            EventManager.instance.SendEvent("PlayerRespawn");
            EventManager.instance.SendEvent("DestroyFallPlat");
            EventManager.instance.SendEvent("RespawnFallPlat");
        }
    }
}