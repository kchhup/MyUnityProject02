using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    private Transform m_transform;
    public float m_speed = 1;
    public int m_life = 1;
    protected float m_rotSpeed = 30;
    internal Renderer m_renderer;
    internal bool m_isActiv = false;
    public int m_point = 10;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        m_renderer = this.GetComponent<Renderer>();

    }
    private void OnBecameVisible()
    {
        m_isActiv = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if (m_isActiv && !this.m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
                if (m_life <= 0)
                {
                    GameManager.Instance.AddScore(m_point);
                    Destroy(this.gameObject);
                }

            }

        }else if (other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);

        }
    }
    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        m_transform.Translate(new Vector3(rx, 0, m_speed * Time.deltaTime));

    }
}
