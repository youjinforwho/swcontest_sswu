using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sculptureController : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        this.Player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            rigid.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag=="Player")
        {
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
                OnDamaged(collision.transform.position);
        }
        */
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }


    void Update()
    {   
        //�����Ӹ��� ������� ����
        transform.Translate(0, -0.1f, 0);

        //ȭ�� ������ ������ ������Ʈ ����
        if(transform.position.y < -5.0f)
         {
             Destroy(gameObject);
         }

        /*
        //�浹 ����
        Vector2 p1 = transform.position;               //ȭ���� �߽� ��ǥ
        Vector2 p2 = this.Player.transform.position;   //�÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;                         
        float d = dir.magnitude;                       
        float r1 = 0.5f;                               //ȭ���� �ݰ�
        float r2 = 1.0f;                               //�÷��̾��� �ݰ�

        if (d < r1 + r2)
         {
            //�浹�� ���� ȭ���� ����
            Destroy(gameObject);
         }*/
    }
}