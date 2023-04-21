using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mikeAudioTrick : MonoBehaviour
{
    public GameObject mike;
    public audioAnimation audioTrick;

    public float moveDistance;
    public AudioClip song;

    private bool isMove = false;

    private Rigidbody2D rigi;
    AudioSource audioSource;

    Vector3 firstDistance, target;

    private void Start()
    {
        // ó�� ������ ��ġ�� ��ư Ŭ�� �� ������ ��ġ�� ����
        firstDistance = transform.position;
        target = firstDistance + new Vector3(moveDistance, 0, 0);

        rigi = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // �̵�
        if (isMove) 
            transform.position = Vector3.MoveTowards(transform.position, target, 1.1f * Time.deltaTime);

        // �ִϸ��̼�
        if(moveDistance > 0)
        {
            // ���ڰ� ��ǥ ������ �������� �� ������� �ִϸ��̼� ����� �����ϰ� ���ڰ� �� �̻� �������� �ʰ� �Ѵ�.
            if (transform.position.x >= target.x)
            {
                isMove = false;
                audioTrick.audioAnim = false;
                rigi.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        else
        {
            if (transform.position.x <= target.x)
            {
                isMove = false;
                audioTrick.audioAnim = false;
                rigi.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    // ��ư Ŭ�� �� �����ϴ� �ڵ�
    public void onClick()
    {
        isMove = true;
        audioTrick.audioAnim = true;

        // �Ҹ� ���
        audioSource.clip = song;
        audioSource.Play();
    }
}