using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    // ��� ���� ����� ���� �ڵ�
    AudioSource audioSource;

    public AudioClip audiobackground;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // �Ҹ� ���
        audioSource.clip = audiobackground;
        audioSource.Play();
    }
}
