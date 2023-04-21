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
        // 처음 의자의 위치와 버튼 클릭 후 움직일 위치를 저장
        firstDistance = transform.position;
        target = firstDistance + new Vector3(moveDistance, 0, 0);

        rigi = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 이동
        if (isMove) 
            transform.position = Vector3.MoveTowards(transform.position, target, 1.1f * Time.deltaTime);

        // 애니메이션
        if(moveDistance > 0)
        {
            // 의자가 목표 지점에 근접했을 때 오디오의 애니메이션 재생을 중지하고 의자가 더 이상 움직이지 않게 한다.
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

    // 버튼 클릭 시 동작하는 코드
    public void onClick()
    {
        isMove = true;
        audioTrick.audioAnim = true;

        // 소리 재생
        audioSource.clip = song;
        audioSource.Play();
    }
}