using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAnimation : MonoBehaviour
{
    Animator anim;
    public bool audioAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // �ִϸ��̼� ���
        anim.SetBool("isButtonClick", audioAnim);
    }
}
