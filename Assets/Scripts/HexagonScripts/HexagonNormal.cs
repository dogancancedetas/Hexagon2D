using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexagonNormal : MonoBehaviour
{
    public static HexagonNormal instance;

    public GameObject hexagon;
    private Animator hexagonAnimator;
    int colorIndex;
    public List<GameObject> matchingTiles = new List<GameObject>();
    public TextMeshProUGUI bombText;

    public int pointValue;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;

        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
        hexagonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckMatches();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color.linear == gameObject.GetComponent<SpriteRenderer>().color.linear)
                matchingTiles.Add(collision.gameObject);
        }
    }


    private void CheckMatches()
    {
        if (matchingTiles.Count >= 2 && BoardManager.instance.isGameStarted)
        {

            foreach (GameObject gameObject in matchingTiles)
                hexagonAnimator.Play("MatchAndRespawn");
        }
        else if (matchingTiles.Count < 2)
            hexagonAnimator.Play("Hexagon");
    }

    private void DestroyAndRespawn()
    {
        matchingTiles.Clear();
        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
        BoardManager.instance.UpdateScore(pointValue);
    }
}
