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

    public float firstx; // ������ ó�� ��ġ�� �����ϴ� ����
    public float moveDistanceRight; // ���������� ������ �� �ִ� �ִ� ����
    public float moveDistanceLeft; // �������� ������ �� �ִ� �ִ� ����
    public int stopMonster; //�����ִ� ����

    private int nextMove; // ������ �����̴� ������ ������ ����
    private bool isRight; // ������ �������� �������� ���ϴ� ����

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

    // �ڵ����� �����̱�
    void move()
    {
        // �ִϸ��̼�
        anim.SetInteger("WalkSpeed", nextMove);
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        if (isRight) // ������
        {
            spriteRenderer.flipX = false;
            nextMove = 1;
            if (rigid.position.x >= firstx + moveDistanceRight)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                isRight = false;
            }
        }
        else // ����
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

    // ���Ͱ� ����ϴ� �ڵ�
   /* public void monsterDie()
    {
        // �� ����
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        // ����������
        spriteRenderer.flipY = true;
        // collider disable
        capsuleCollider2D.enabled = false;
        // ���� ����Ʈ
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //��Ȱ��ȭ
        Invoke("DeActive", 1);
    }
   */

    // ������Ʈ�� ������ �ʰ� �ϴ� �ڵ�
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