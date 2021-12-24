using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonNormal : MonoBehaviour
{
    public GameObject hexagon;
    int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
    }
}
