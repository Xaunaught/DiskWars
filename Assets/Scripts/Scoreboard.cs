using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
    public List<GameObject> players;
    public int score1 = 0;
    public int score2 = 0;
    public int score3 = 0;
    public int score4 = 0;
    public Text scoreBoard;

    // Use this for initialization
    void Start () {
        players = new List<GameObject>();
        UpdateScore();
    }

    // Update is called once per frame
    void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        players.Add(other.gameObject);
        print("Player added");
        if (players.Count == 1)
        {
            StartCoroutine("ScoreIncrease");
            //add to score;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(players.Contains(other.gameObject))
        {
            GameObject temp = other.gameObject;
            players.Remove(temp);
            print("player removed");
            //when a player leaves score needs to start counting
        }
    }

    IEnumerator ScoreIncrease()
    {
        print("player 0 tage: " + players[0].tag);
        if(players[0].tag == "Player1")
        {
            while (players.Count == 1)
            {
                score1 += 1;
                yield return new WaitForSeconds(1);
                print("Player 1 score = " + score1);
                UpdateScore();
            }


        }
        else if (players[0].tag == "Player2")
        {
            while (players.Count == 1)
            {
                 score2 += 1;
                yield return new WaitForSeconds(1);
                print("Player 2 score = " + score2);
                UpdateScore();
            }
        }
        else if (players[0].tag == "Player3")
        {
            while (players.Count == 1)
            {
                score3 += 1;
                yield return new WaitForSeconds(1);
                print("Player 3 score = " + score3);
                UpdateScore();
            }
        }
        else if (players[0].tag == "Player4")
        {
            while (players.Count == 1)
            {
                score4 += 1;
                yield return new WaitForSeconds(1);
                print("Player41 score = " + score4);
                UpdateScore();
            }
        }
    }

    void UpdateScore()
    {
        scoreBoard.text = "Player 1: " + score1 + "\n" + "Player 2: " + score2 + "\n" + "Player 3: " + score3 + "\n" + "Player 4: " + score4;
    }
}
