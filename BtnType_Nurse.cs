using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType_Nurse : MonoBehaviour
{
    public BTNTypeN currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNTypeN.First:
                SceneManager.LoadScene("1-1");
                break;
            case BTNTypeN.Second:
                SceneManager.LoadScene("1-2");
                break;
            case BTNTypeN.Third:
                SceneManager.LoadScene("1-3");
                break;
            case BTNTypeN.Fourth:
                SceneManager.LoadScene("1-4");
                break;
            case BTNTypeN.Back:
                SceneManager.LoadScene("Main");
                break;


        }
    }
}
