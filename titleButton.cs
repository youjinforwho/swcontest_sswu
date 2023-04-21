using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
    // 버튼 클릭 시 씬을 바꾼다.
    public void onClick()
    {
        SceneManager.LoadScene("main");
    }
}
