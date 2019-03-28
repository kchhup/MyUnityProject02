using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("MyGame/Player")]
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
