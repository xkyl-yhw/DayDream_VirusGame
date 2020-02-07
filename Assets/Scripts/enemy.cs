using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int enemyBlood = 5;
    private GameObject enemyCreate;

    private void Start()
    {
        enemyCreate = GameObject.Find("Ins");
    }

    private void Update()
    {
        if (enemyBlood < 0)
        {
            enemyCreate.GetComponent<CreateEnemy>().deleteEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void minBlood()
    {
        enemyBlood--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().minPoint();
        }
    }
}
