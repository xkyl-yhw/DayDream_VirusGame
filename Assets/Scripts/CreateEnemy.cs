using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject[] enemyIns;
    private float preTime;
    public float interTime = 0.5f;
    List<GameObject> enemyList = new List<GameObject>();
    public float enemyMovingSpeed = 10;

    private void Update()
    {
        if (Time.time - preTime > interTime)
        {
            preTime = Time.time;
            int insPos = Random.Range(-5, 6);
            int enemyRam = Random.Range(0, enemyIns.Length);
            GameObject tempEnemy = Instantiate(enemyIns[enemyRam], transform.position + new Vector3(0.5f * (float)(insPos), 0), Quaternion.identity);
            enemyList.Add(tempEnemy);
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            Vector3 tempPos = enemyList[i].transform.position;
            tempPos.y -= enemyMovingSpeed * Time.deltaTime;
            if (tempPos.y < -6)
            {
                tempPos.y = this.transform.position.y;
            }
            enemyList[i].transform.position = tempPos;
        }
    }

    public void deleteEnemy(GameObject temp)
    {
        enemyList.Remove(temp);
    }
}
