using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;
    public bool isGameover = false;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = false;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D colider;
    AudioSource audioSource;

    public string changeScenes; // 가고자하는 씬을 입력받는다. (1, 2, 3, 4)중에서 입력

    public GameObject UIRestartBtn;// 재시작
    public GameObject healpack; //힐팩

    // 모바일 용 변수
    [HideInInspector] // 함부로 수정할 수 없게 한다.
    public bool isWalkL = false;
    [HideInInspector]
    public bool isWalkR = false;
    [HideInInspector]
    public bool isfight = false;

    // BGM용 변수
    public AudioClip audioJump;
    public AudioClip audioAttack;
    public AudioClip audioDamage;
    public AudioClip audioDie;
    public AudioClip audioFinish;
    public AudioClip audioItem;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        colider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //플레이어 점프 구현
        if (Input.GetButtonDown("Jump") && (isJump == false))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            isJump = true;

            // 소리 재생
            audioSource.clip = audioJump;
            audioSource.Play();
        }

        //속도 제어
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //방향 제어
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //애니메이션
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed)//Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))//Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                    isJump = false;
                }
            }
        }

        // 모바일 버튼을 통한 이동의 방향
        if (isWalkL) // 왼쪽
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            spriteRenderer.flipX = true;
        }
        else if (isWalkR) // 오른쪽
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Next Stage
        if (collision.gameObject.tag == "Finish")
        {
            // 소리 재생
            audioSource.clip = audioFinish;
            audioSource.Play();

            // 클리어 소리 재생을 위해 시간 딜레이를 준다.
            Invoke("timeDelay", 0.8f);
        }

        //바이러스와 충돌했을 경우
        if (collision.gameObject.tag == "Virus")
        {
            OnDamaged(collision.transform.position);
        }

        //힐팩을 먹었을 경우
        if (collision.gameObject.tag == "Healpack")
        {
            RestoreHealth(collision.transform.position);

            // 소리 재생
            audioSource.clip = audioItem;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            // 공격
            if (rigid.velocity.y < 0 && (transform.position.y > collision.transform.position.y))
            {
                OnAttack(collision.transform);

                // 소리 재생
                audioSource.clip = audioAttack;
                audioSource.Play();
            }
            else
            {
                // 소리 재생
                audioSource.clip = audioDie;
                audioSource.Play();

                OnDie();
            }
        }
    }

    // 몬스터를 공격
    void OnAttack(Transform enemy)
    {
        //반동
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        //몬스터의 죽음
        monsterMove monsterMove = enemy.GetComponent<monsterMove>();
        monsterMove.monsterDie();
    }

    // 클리어 소리 재생을 위해 시간 딜레이를 준다.
    public void timeDelay() 
    {
        changeUI(changeScenes);
    }

    //죽었을 때 효과
    public void OnDie()
    {
        //sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //collider disable
        colider.enabled = false;
        //죽음 이펙트
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        //destroy

        anim.SetTrigger("doDamaged");

        Invoke("DeActive", 1);

        UIRestartBtn.SetActive(true);
        //Time.timeScale=0; 
    }

    public void VelocityZero() //속도를 0으로
    {
        rigid.velocity = Vector2.zero;
    }

    public void Restart() //재시작
    {
        isGameover = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void DeActive() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    void OnDamaged(Vector2 targetPos)
    {
        //Change Layer(Immortal Active)
        gameObject.layer = 11;

        //View Alpha 플레이어를 투명하게
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Reaction Force 튕겨내기 효과
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        maxSpeed = 1;

        // 소리 재생
        audioSource.clip = audioDamage;
        audioSource.Play();
    }

    void RestoreHealth(Vector2 targetPos)
    {
        //Change Layer(Immortal Active)
        gameObject.layer = 1;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        maxSpeed = 5;
        healpack.SetActive(false); //힐팩 비활성화

    }

    // 모바일 용 버튼으로 플레이어 이동하기
    // 버튼 눌렀을 때
    public void buttonDown(string type)
    {
        switch (type)
        {
            case "U": // 점프
                if (isJump == false)
                {
                    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    anim.SetBool("isJumping", true);

                    // 점프 상태임을 코드에 알려 무한 점프를 막는다.
                    isJump = true;

                    // 소리 재생
                    audioSource.clip = audioJump;
                    audioSource.Play();
                }
                break;
            case "L": // 왼쪽
                isWalkL = true;
                break;
            case "R": // 오른쪽
                isWalkR = true;
                break;
        }
    }

    // 버튼 누르지 않을 때
    public void buttonup(string type)
    {
        switch (type)
        {
            case "U": // 점프
                break;
            case "L": // 왼쪽
                isWalkL = false;
                break;
            case "R": // 오른쪽
                isWalkR = false;
                break;
        }
    }

    public void changeUI(string type)
    {
        switch (type)
        {
            case "1":
                SceneManager.LoadScene("Nurse");
                break;
            case "2":
                SceneManager.LoadScene("Art");
                break;
            case "3":
                SceneManager.LoadScene("Music");
                break;
            case "4":
                SceneManager.LoadScene("Computer");
                break;
        }
    }
}