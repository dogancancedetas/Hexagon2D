using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonNormal : MonoBehaviour
{

    public GameObject hexagon;
    public int colorIndex;
    public List<GameObject> matchingTiles = new List<GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color.linear == gameObject.GetComponent<SpriteRenderer>().color.linear)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
