
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viralInfection : MonoBehaviour
{
    public GameObject virusPrefab;
    public float spawnRateMin=0.5f; //최소 생성 주기
    public float spawnRateMax=3f; //최대 생성 주기
    public int count=0;

    private Transform target;
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간


    void Start(){
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn=0f;
        //바이러스 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate=Random.Range(spawnRateMin, spawnRateMax);
        //target=FindObjectOfType<PlayerController>().transform;
    }

    void Update(){
        //timeAfterSpawn 갱신
        timeAfterSpawn+=Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if((timeAfterSpawn>=spawnRate)&&(count<2))
        {
            //누적된 시간을 리셋
            timeAfterSpawn=0f;


            GameObject virus=Instantiate(virusPrefab, transform.position, transform.rotation); //바이러스가 있는 위치에서 복제
            
            virus.transform.LookAt(target);

            spawnRate=Random.Range(spawnRateMin, spawnRateMax);
            count++;
            
        }
    }

}
