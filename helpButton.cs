using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpButton : MonoBehaviour
{
    public GameObject pannel;

    // 버튼 클릭 시 패널이 보이게 한다.
    public void clickHelp()
    {
        pannel.gameObject.SetActive(true);
    }

    // 버튼 클릭 시 패널이 안보이게 한다.
    public void closeHelp()
    {
        pannel.gameObject.SetActive(false);
    }
}
