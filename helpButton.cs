using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpButton : MonoBehaviour
{
    public GameObject pannel;

    // ��ư Ŭ�� �� �г��� ���̰� �Ѵ�.
    public void clickHelp()
    {
        pannel.gameObject.SetActive(true);
    }

    // ��ư Ŭ�� �� �г��� �Ⱥ��̰� �Ѵ�.
    public void closeHelp()
    {
        pannel.gameObject.SetActive(false);
    }
}
