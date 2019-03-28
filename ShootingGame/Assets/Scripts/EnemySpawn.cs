using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    protected Transform m_transform;
    public Transform m_enemy;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        Debug.Log(SpawnEnemy().ToString());
        StartCoroutine(SpawnEnemy());
    }


    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(2, 10));
        Instantiate(m_enemy, m_transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "item.png", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
