using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gamePoint = 0;
    public Text pointBoard;
    public int playerLife = 10;
    public Text lifeBoard;
    public int day=1;
    public Text dayBoard;

    private int[] pointArray = { 10, 25, 40, 65, 95, 135, 180, 230, 275, 315, 365, 420, 475, 535 };


    private void Start()
    {
        StartCoroutine(showDay());
        lifeBoard.text = "Lifes:" + playerLife;
        gamePoint = 0;
        day = 1;
    }

    private void Update()
    {
        if (gamePoint > pointArray[day-1])
        {
            Debug.Log(pointArray[day - 1]);
            ++day;
            dayBoard.text = "Day:" + day;
            StartCoroutine(showDay());
        }
        if (playerLife <= 0)
        {
            Restart();
        }
    }

    private IEnumerator showDay()
    {
        dayBoard.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        dayBoard.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    } 

    public void addPoint(int point)
    {
        gamePoint += point;
        pointBoard.text = "marks:" + gamePoint;
    }

    public void minPoint()
    {
        playerLife--;
        lifeBoard.text = "Lifes:" + playerLife;
    }
}
