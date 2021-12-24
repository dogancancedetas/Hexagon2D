using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonNormal : MonoBehaviour
{
    public GameObject hexagon;
    private Animator hexagonAnimator;
    public int colorIndex;
    public List<GameObject> matchingTiles = new List<GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
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
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color.linear == gameObject.GetComponent<SpriteRenderer>().color.linear)
            {
                matchingTiles.Add(collision.gameObject);
            }
        }
    }

    private void CheckMatches()
    {
        if (matchingTiles.Count >= 2)
            foreach(GameObject gameObject in matchingTiles) 
            {
                hexagonAnimator.Play("MatchAndRespawn");
                break;
            }
        else
        {
            hexagonAnimator.Play("Hexagon");
        }
        
    }

    private void DestroyAndRespawn()
    {
        matchingTiles.Clear();
        colorIndex = Random.Range(0, BoardManager.instance.hexagonColor.Length);
        hexagon.GetComponent<SpriteRenderer>().color = BoardManager.instance.hexagonColor[colorIndex];
    }
}
