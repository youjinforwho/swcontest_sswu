using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
    // ��ư Ŭ�� �� ���� �ٲ۴�.
    public void onClick()
    {
        SceneManager.LoadScene("main");
    }
}
