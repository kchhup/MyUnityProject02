using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_speed = 10;
    public float m_liveTime = 1;
    public int m_power = 1;
    protected Transform m_transfrom;
    // Start is called before the first frame update
    void Start()
    {
        m_transfrom = this.transform;
        Destroy(this.gameObject,m_liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        m_transfrom.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enemy") != 0)
            return;
        Destroy(this.gameObject);
    }
}
