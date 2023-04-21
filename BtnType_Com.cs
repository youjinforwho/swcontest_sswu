using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType_Com : MonoBehaviour
{
    public BTNTypeN currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNTypeN.First:
                SceneManager.LoadScene("4-1");
                break;
            case BTNTypeN.Second:
                SceneManager.LoadScene("4-2");
                break;
            case BTNTypeN.Third:
                SceneManager.LoadScene("4-3");
                break;
            case BTNTypeN.Fourth:
                SceneManager.LoadScene("4-4");
                break;
            case BTNTypeN.Back:
                SceneManager.LoadScene("Main");
                break;


        }
    }
}
