using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapManager : MonoBehaviour
{
    public GameObject topTrigger, bottomTrigger;
    bool isTop, isBottom, isPivot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPivot)
            {
                BoardManager.instance.isGameStarted = true;
                transform.position = new Vector3(transform.position.x + 0.764f, transform.position.y + 0.441f);
            }
            else if (isTop)
                transform.position = new Vector3(transform.position.x, transform.position.y + (-0.882f));
            else if (isBottom)
                transform.position = new Vector3(transform.position.x - 0.764f, transform.position.y - (-0.441f));
        }
    }

    private void OnMouseEnter()
    {
        topTrigger.SetActive(true);
        bottomTrigger.SetActive(true);
        isPivot = true;
    }

    private void OnMouseExit()
    {
        topTrigger.SetActive(false);
        bottomTrigger.SetActive(false);
        isPivot = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopTrigger")
            isTop = true;
        else if (collision.gameObject.tag == "BottomTrigger")
            isBottom = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopTrigger")
            isTop = false;
        else if (collision.gameObject.tag == "BottomTrigger")
            isBottom = false;
    }
}
