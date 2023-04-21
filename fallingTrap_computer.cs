using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingTrap_computer : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject trick_computer;
    float sponTime = 3.0f;
    SpriteRenderer spriteRenderer;
    

    void Update()
    {
       sponTime -= Time.deltaTime;
        if (sponTime < 0)
        {
            Instantiate(trick_computer, transform.position, Quaternion.identity);
            sponTime = 3.0f;
        }
    }
   
    void Start()
    {
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
        //떨어지는 본체와 플레이어 부딪히면 플레이어 사망   
        if (collision.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
        }
        //본체와 그라운드 태그 만나면 본체 없애기
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
    
}
