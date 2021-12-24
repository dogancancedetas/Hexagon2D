using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;
    public GameObject hexagonPrefab;
    public int xSize = 8;
    public int ySize = 9;

    float xOffSet = 0.764f;
    float yOffSet = 0.882f;

    public Color[] hexagonColor = new Color[]
    {
        new Color(0.95f, 0.26f, 0.21f),
        new Color(0.61f, 0.15f, 0.69f),
        new Color(0.24f, 0.31f, 0.7f),
        new Color(0, 0.73f, 0.83f),
        new Color(0.29f, 0.68f, 0.31f)
    };

    void Awake()
    {
        instance = GetComponent<BoardManager>();
        Camera.main.transform.position = new Vector3((xSize / 2 - 0.5f) * xOffSet, ySize / 2 * yOffSet, Camera.main.transform.position.z);
        SetBoard();
    }

    private void SetBoard()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float yPos = y * yOffSet;

                //Are we on an odd row?
                if (x % 2 == 1)
                    yPos += yOffSet / 2;

                GameObject newHexagon = Instantiate(hexagonPrefab, new Vector3(x * xOffSet, yPos), hexagonPrefab.transform.rotation);

                newHexagon.name = "Hexagon[" + x + "," + y + ")";
                newHexagon.transform.parent = transform;

            }
        }
    }

}
