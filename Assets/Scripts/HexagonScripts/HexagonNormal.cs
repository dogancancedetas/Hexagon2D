using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexagonNormal : MonoBehaviour
{
    public static HexagonNormal instance;
    public GameObject hexagon;
    List<GameObject> matchingTiles = new List<GameObject>();
    protected Animator hexagonAnimator;

    int colorIndex;
    [SerializeField]
    protected int pointValue = 10;

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
        if(BoardManager.instance.isGameStarted)
        CheckMatches();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hexagon" && gameObject.tag == "Hexagon")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color.linear == gameObject.GetComponent<SpriteRenderer>().color.linear)
                matchingTiles.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hexagon" && gameObject.tag == "Hexagon")
        {
            matchingTiles.Add(gameObject);

            if (other.gameObject.GetComponent<SpriteRenderer>().color.linear == gameObject.GetComponent<SpriteRenderer>().color.linear)
                matchingTiles.Add(gameObject);
        }
    }

    private void CheckMatches()
    {
        if (matchingTiles.Count >= 2)
        {
            foreach (GameObject gameObject in matchingTiles)
                hexagonAnimator.Play("MatchAndRespawn");
        }
        else if (matchingTiles.Count < 1)
        {
            hexagonAnimator.Play("Hexagon");
            matchingTiles.Clear();
        }
    }

    private void DestroyAndRespawn()
    {
        matchingTiles.Clear();
        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
        BoardManager.instance.UpdateScore(pointValue);
    }
}
