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
        // 애니메이션 재생
        anim.SetBool("isButtonClick", audioAnim);
    }
}
