using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskEffect : MonoBehaviour
{
    private GameObject gameManager;
    public int pointNum;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().addPoint(pointNum);
            transform.parent.gameObject.GetComponent<maskCreate>().deleteMask(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
