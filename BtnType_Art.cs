using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType_Art : MonoBehaviour
{
    public BTNTypeN currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNTypeN.First:
                SceneManager.LoadScene("2-1");
                break;
            case BTNTypeN.Second:
                SceneManager.LoadScene("2-2");
                break;
            case BTNTypeN.Third:
                SceneManager.LoadScene("2-3");
                break;
            case BTNTypeN.Fourth:
                SceneManager.LoadScene("2-4");
                break;
            case BTNTypeN.Back:
                SceneManager.LoadScene("Main");
                break;


        }
    }
}
