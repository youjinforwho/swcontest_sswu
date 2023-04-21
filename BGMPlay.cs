using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    // 배경 음악 재생을 위한 코드
    AudioSource audioSource;

    public AudioClip audiobackground;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // 소리 재생
        audioSource.clip = audiobackground;
        audioSource.Play();
    }
}
