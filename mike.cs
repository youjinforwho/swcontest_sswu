using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mike : MonoBehaviour
{
    public GameObject player;
    public Button button;

    private void FixedUpdate()
    {
        float dis = Vector2.Distance(player.transform.position, transform.position);

        // 마이크에 가까이 가면 버튼 활성화
        if(dis <= 1.0f)
            button.gameObject.SetActive(true);
        // 마이크와 멀어지면 버튼 비활성화
        else
            button.gameObject.SetActive(false);
    }
}
