using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType_Music : MonoBehaviour
{
    public BTNTypeN currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNTypeN.First:
                SceneManager.LoadScene("3-1");
                break;
            case BTNTypeN.Second:
                SceneManager.LoadScene("3-2");
                break;
            case BTNTypeN.Third:
                SceneManager.LoadScene("3-3");
                break;
            case BTNTypeN.Fourth:
                SceneManager.LoadScene("3-4");
                break;
            case BTNTypeN.Back:
                SceneManager.LoadScene("Main");
                break;


        }
    }
}
