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

        // ����ũ�� ������ ���� ��ư Ȱ��ȭ
        if(dis <= 1.0f)
            button.gameObject.SetActive(true);
        // ����ũ�� �־����� ��ư ��Ȱ��ȭ
        else
            button.gameObject.SetActive(false);
    }
}
