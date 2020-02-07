using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public GameObject bulletIns;
    List<GameObject> bulletList = new List<GameObject>();
    public float bulletOffset = 1;
    public float bulletSpeed = 20;
    public float highLimit = 100;
    private float preTiem;
    public float interTime;

    private void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject temp = Instantiate(bulletIns, this.transform.position - new Vector3(0, bulletOffset), Quaternion.identity, this.transform);
            bulletList.Add(temp);
        }
    }

    private void Update()
    {
        if (Time.time - preTiem > interTime)
        {
            preTiem = Time.time;
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].transform.position.y < this.gameObject.transform.position.y)
                {
                    bulletList[i].transform.position = new Vector2(bulletList[i].transform.position.x, this.gameObject.transform.position.y);
                    bulletList[i].transform.parent = null;
                    break;
                }
            }
        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            if (bulletList[i].transform.parent == null)
            {
                Vector2 tempPos = bulletList[i].transform.position;
                tempPos.y += bulletSpeed * Time.deltaTime;
                if (tempPos.y > highLimit)
                {
                    tempPos = this.transform.position - new Vector3(0, bulletOffset);
                    bulletList[i].transform.SetParent(this.transform);
                }
                bulletList[i].transform.position = tempPos;
            }
        }
    }

    public void deleteBullet(GameObject temp)
    {
        Vector2 tempPos = this.transform.position - new Vector3(0, bulletOffset);
        temp.transform.position = tempPos;
        temp.transform.SetParent(this.transform);
    }
}
