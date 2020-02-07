using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCreate : MonoBehaviour
{
    public GameObject[] maskArray;
    private float preTime;
    public float interTime;
    public float maskSpeed = 2;
    List<GameObject> maskList = new List<GameObject>();

    private void Update()
    {
        if (Time.time - preTime > interTime)
        {
            preTime = Time.time;
            int maskNum = Random.Range(0, maskArray.Length);
            int maskPos = Random.Range(-5, 6);
            GameObject tempMask = Instantiate(maskArray[maskNum], transform.position + new Vector3(0.5f * maskPos, 0), Quaternion.identity, this.transform);
            maskList.Add(tempMask);
        }
        if (maskList.Count != 0)
            for (int i = 0; i < maskList.Count; i++)
            {
                Vector2 tempPos = maskList[i].transform.position;
                tempPos.y -= maskSpeed * Time.deltaTime;
                if (tempPos.y < -6)
                {
                    tempPos.y = this.transform.position.y;
                }
                maskList[i].transform.position = tempPos;
            }
    }

    public void deleteMask(GameObject tmep)
    {
        maskList.Remove(tmep);
    }
}
