using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool hitPlayer = false;
    private void Update()
    {
        if (Input.anyKey)
        {
            inputFunc();
        }
    }

    public void inputFunc()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 pos = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Player")
                    {
                        hitPlayer = true;
                    }
                    else
                    {
                        hitPlayer = false;
                    }
                }
                else
                {
                    hitPlayer = false;
                }

            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (hitPlayer)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 pos = new Vector2(mousePos.x, mousePos.y);
                    transform.position = pos;
                }
            }
        }
    }
}
