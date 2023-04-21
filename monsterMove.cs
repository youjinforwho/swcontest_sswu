using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsuleCollider2D;
    PlayerMove playerMove;

    public float firstx; // 몬스터의 처음 위치를 저장하는 변수
    public float moveDistanceRight; // 오른쪽으로 움직일 수 있는 최대 범위
    public float moveDistanceLeft; // 왼쪽으로 움직일 수 있는 최대 범위
    public int stopMonster; //멈춰있는 몬스터

    private int nextMove; // 다음에 움직이는 방향을 저장한 변수
    private bool isRight; // 오른쪽 방향으로 향할지를 정하는 변수

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        playerMove = GetComponent<PlayerMove>();
    }

    void FixedUpdate()
    {
        if (stopMonster == 0)
        {
            stop();
        }
        else
            move();
    }

    // 자동으로 움직이기
    void move()
    {
        // 애니메이션
        anim.SetInteger("WalkSpeed", nextMove);
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        if (isRight) // 오른쪽
        {
            spriteRenderer.flipX = false;
            nextMove = 1;
            if (rigid.position.x >= firstx + moveDistanceRight)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                isRight = false;
            }
        }
        else // 왼쪽
        {
            spriteRenderer.flipX = true;
            nextMove = -1;
            if (rigid.position.x <= firstx - moveDistanceLeft + 0.7f)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                isRight = true;
            }
        }


        Invoke("move", 0.5f);
    }

    void stop()
    {
        anim.SetInteger("WalkSpeed", 0);
        rigid.velocity = new Vector3(0, rigid.velocity.y);
    }

    // 몬스터가 사망하는 코드
   /* public void monsterDie()
    {
        // 색 변경
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        // 뒤집어지기
        spriteRenderer.flipY = true;
        // collider disable
        capsuleCollider2D.enabled = false;
        // 죽음 이펙트
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //비활성화
        Invoke("DeActive", 1);
    }
   */

    // 오브젝트가 보이지 않게 하는 코드
    void DeActive()
    {
        gameObject.SetActive(false);
    }
    public void monsterDie()
    {
        //sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //sprite Flip Y
        spriteRenderer.flipY = true;
        capsuleCollider2D.enabled = false;
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        Invoke("DeActive", 5);
    }
}