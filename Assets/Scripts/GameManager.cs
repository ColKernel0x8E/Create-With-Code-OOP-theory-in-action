using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Raft raft;
    [SerializeField] Cargo[] cargo;
    public TextMeshProUGUI crossingsText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI whoAteWhomText;
    public TextMeshProUGUI gameWonText;

    // ENCAPSULATION
    bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver; } }

    int numberCrossings = 0;

    void Start()
    {
        crossingsText.text = "Crossings: " + numberCrossings;
    }

    void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void CrossRiver()
    {
        raft.MoveRaft();
        CheckKills();
        numberCrossings++;
        crossingsText.text = "Crossings: " + numberCrossings;
        
    }

    void GameOver(string eater, string eatee)
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        whoAteWhomText.text = "The " + eater + " ate the " + eatee;
    }

    void GameWon()
    {
        isGameOver = true;
        gameWonText.gameObject.SetActive(true);
    }

    void CheckKills()
    {
        foreach (Cargo x in cargo)
        {
            foreach (Cargo y in cargo)
            {
                // if x and y are different, on the same bank, neither is on the raft, and the raft is at the other bank - check diet
                if (!x.IsOnRaft && !y.IsOnRaft && x != y && x.IsRightBank == y.IsRightBank && x.IsRightBank != raft.IsRightBank)
                {
                    string[] xDiet = x.Diet();
        
                    if (xDiet != null)
                    {
                        string yName = y.GetType().Name;

                        foreach (string dietItem in xDiet)
                        {
                            if (dietItem == yName)
                            {
                                Destroy(y.gameObject);
                                x.EatAnimation();
                                GameOver(x.GetType().Name.ToLower(), yName.ToLower());
                            }
                        }
                    }
                }
            }
            
        }
    }

    public void CheckWinConditions()
    {
        bool gameWon = true;
        foreach (Cargo x in cargo)
        {
            if (!x.IsRightBank || x.IsOnRaft)
            {
                gameWon = false;
            }
        }

        if (gameWon)
        {
            GameWon();
        }
    }
}
