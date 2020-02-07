using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletIns : MonoBehaviour
{
    private GameObject bulletManager;

    private void Start()
    {
        bulletManager = GameObject.Find("bulletManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<enemy>().minBlood();
            bulletManager.GetComponent<bulletManager>().deleteBullet(this.gameObject);
        }
    }
}
