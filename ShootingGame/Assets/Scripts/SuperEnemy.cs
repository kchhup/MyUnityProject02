using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
