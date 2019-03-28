# MyUnityProject02
## unity游戏界面截图
![游戏截图01](https://github.com/kchhup/MyUnityProject02/blob/master/picture/01.jpg) 
![游戏截图02](https://github.com/kchhup/MyUnityProject02/blob/master/picture/02.jpg) 
![游戏截图03](https://github.com/kchhup/MyUnityProject02/blob/master/picture/03.jpg) 

## 游戏体Player控制代码
```

public class Player : MonoBehaviour
{
    public float m_speed = 1;
    private Transform m_tranform;
    public Transform m_rocket;
    public float m_rocketTimer = 0;
    public int m_life = 10;
    public AudioClip m_shootClip;
    protected AudioSource m_audio;
    public Transform m_explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        m_tranform = this.transform;
        m_audio = this.GetComponent < AudioSource >();
    }

    // Update is called once per frame
    void Update()
    {
        float movev = 0;
        float moveh = 0;
        if (Input.GetKey(KeyCode.UpArrow)) {
            movev -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movev += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            moveh += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveh -= m_speed * Time.deltaTime;
        }
        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            if (Input.GetKey(KeyCode.Return))
            {
                Instantiate(m_rocket, m_tranform.position, m_tranform.rotation);
                m_audio.PlayOneShot(m_shootClip);
            }
        }
        this.m_tranform.Translate(new Vector3(moveh, 0, movev));

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") != 0)
        {
            m_life -= 1;
            GameManager.Instance.ChangeLife(m_life);
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, this.m_tranform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}

```

### 敌人Enemy控制代码

```

public class SuperEnemy : Enemy
{
    //public Transform m_transform;
    public Transform m_rocket;
    protected float m_fireTimer = 2;
    protected Transform m_player;
    private void Awake()
    {
        this.transform.Rotate(0, 180, 0);
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            m_player = obj.transform;

        }
    }
    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;
        if (m_fireTimer <= 0)
        {
            m_fireTimer = 2;
            if (m_player != null)
            {
                Vector3 relativePos = this.transform.position - m_player.position;
                Instantiate(m_rocket, this.transform.position, Quaternion.LookRotation(relativePos));
            }
        }
        //base.UpdateMove();

        this.transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
        
    }
}



```
