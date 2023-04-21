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
        //프레임마다 등속으로 낙하
        transform.Translate(0, -0.1f, 0);

        //화면 밖으로 나오면 오브젝트 삭제
        if(transform.position.y < -5.0f)
         {
             Destroy(gameObject);
         }

        /*
        //충돌 판정
        Vector2 p1 = transform.position;               //화살의 중심 좌표
        Vector2 p2 = this.Player.transform.position;   //플레이어의 중심 좌표
        Vector2 dir = p1 - p2;                         
        float d = dir.magnitude;                       
        float r1 = 0.5f;                               //화살의 반경
        float r2 = 1.0f;                               //플레이어의 반경

        if (d < r1 + r2)
         {
            //충돌한 경우는 화살을 지움
            Destroy(gameObject);
         }*/
    }
}