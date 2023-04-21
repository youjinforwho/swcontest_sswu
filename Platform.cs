using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject flag; //깃발
    private bool stepped=false; //플레이어 캐릭터가 밟았는가
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        //충돌한 상대방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
        if(collision.collider.tag=="Player"&&!stepped){
            //밟힘 상태를 참으로 변경하고 깃발을 활성화
            flag.SetActive(true);
            stepped=true;
            spriteRenderer.color=new Color(0,0,0,0.4f);
        }
    }
}
