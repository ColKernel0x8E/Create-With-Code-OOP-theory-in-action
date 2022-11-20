using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    GameManager gameManager;

    // ENCAPSULATION
    public bool isRightBank;
    public bool IsRightBank { get { return isRightBank; } }
    public bool isEmpty { get; set; }

    Vector3 startPosition;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;

        isRightBank = false;
        isEmpty = true;
    }

    public void MoveRaft()
    {
        // move raft to other bank
        if (!isRightBank)
        {
            transform.position += new Vector3(16.3f, 0, 0);
        }
        else
        {
            transform.position = startPosition;
        }
        
        isRightBank = !isRightBank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
