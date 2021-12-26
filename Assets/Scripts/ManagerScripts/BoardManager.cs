using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;
    public GameObject hexagonPrefab;

    [SerializeField]
    int xSize = 8, ySize = 9;

    float xOffSet = 0.764f;
    float yOffSet = 0.882f;

    public Color[] hexagonColor = new Color[]
    {
        new Color(0.54f, 0.17f, 0.15f),
        new Color(0.33f, 0.13f, 0.36f),
        new Color(0.2f, 0.24f, 0.48f),
        new Color(0.28f, 0.57f, 0.61f),
        new Color(0.3f, 0.55f, 0.31f)
    };

    internal bool isGameStarted;

    public TextMeshProUGUI scoreText;
    public int score;

    void Awake()
    {
        if (instance == null)
            instance = this;

        Camera.main.transform.position = new Vector3((xSize / 2 - 0.5f) * xOffSet, ySize / 2 * yOffSet, Camera.main.transform.position.z);
        SetBoard();
    }

    private void SetBoard()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GenerateHexagon(x, y);
            }
        }
    }

    private void GenerateHexagon(int x, int y)
    {
        float yPos = y * yOffSet;

        //Are we on an odd row?
        if (x % 2 == 1)
            yPos += yOffSet / 2;

        GameObject newHexagon = Instantiate(hexagonPrefab, new Vector3(x * xOffSet, yPos), hexagonPrefab.transform.rotation);
        newHexagon.name = "Hexagon[" + x + "," + y + "]";
        newHexagon.transform.parent = transform;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

}
