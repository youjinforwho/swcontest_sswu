using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string sceneName;
    public string category;
    public bool isGameover=false;
    public Text timeText; //시간을 화면에 표시하는 텍스트 변수
    private float passedTime;

    public int time=0;
    public PlayerMove player;

    public GameObject UIRestartBtn; //재시작 버튼
    public GameObject UIBacktoMenuBtn; //메뉴로 돌아가는 버튼
    public GameObject UIResumeBtn; //재개 버튼
    public GameObject UIOptionBtn; //옵션 버튼
    public GameObject UIOptionBoardBtn; //옵션 버튼 눌렀을 때 활성화 되는 버튼

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
            HealthDown();

        PlayerReposition();       
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    public void HealthDown() //체력 감소
    {
        Time.timeScale=0;
        isGameover=true;
        Debug.Log("죽었습니다!");
        UIRestartBtn.SetActive(true);
    }

    public void Restart()
    {
        isGameover=false;
        Time.timeScale=1;
        SceneManager.LoadScene(sceneName); //인자(sceneName)의 Scene으로 이동한다.
    }

    public void Option()
    {
        UIOptionBoardBtn.SetActive(true); //옵션 버튼 눌렀을때
        Time.timeScale=0;
    }

    public void Resume()
    {
        Time.timeScale=1;
        UIOptionBoardBtn.SetActive(false); //옵션 버튼 비활성화
    }
    
    public void BacktoMenu() //메뉴로 돌아가는 버튼
    {
        isGameover=true;
        Time.timeScale=1;
        UIOptionBoardBtn.SetActive(false);
        SceneManager.LoadScene(category);
    }
    void Start(){
        passedTime=0f;
    }

    void Update(){
        if(!isGameover) //시간 표시
        {
            passedTime+=Time.deltaTime;
            timeText.text="Time : "+(int)passedTime;
        }
    }
    
}
