using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [DisallowMultipleComponent]
public class Cargo : MonoBehaviour
{
    Raft raft;
    GameManager gameManager;
    protected string[] diet;

    // ENCAPSULATION
    bool isRightBank = false;
    public bool IsRightBank { get { return isRightBank; } }
    bool isOnRaft = false;
    public bool IsOnRaft { get { return isOnRaft; } }

    float shiftXPosition = 32f;
    Vector3 startPosition;

    // There has to be a better of setting diet than through initialisation at start
    public virtual void Start()
    {
        raft = GameObject.Find("Raft").GetComponent<Raft>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;
    }

    void UnloadFromRaft()
    {
        isRightBank = raft.IsRightBank;
        isOnRaft = false;
        raft.isEmpty = true;
        transform.parent = null;

        if (!isRightBank)
        {
            transform.position = startPosition;
        }
        else
        {
            transform.position = startPosition + new Vector3(shiftXPosition, 0, 0);
        }

        gameManager.CheckWinConditions();
    }

    void LoadOntoRaft()
    {
        isOnRaft = true;
        raft.isEmpty = false;

        transform.parent = raft.transform;
        transform.localPosition = new Vector3 (4.82f, startPosition.y - raft.transform.position.y + 0.2f, -0.5f);
    }

    // ABSTRACTION
    void OnMouseDown()
    {
        if (!gameManager.IsGameOver)
        {
            if (isOnRaft)
            {
                UnloadFromRaft();
            }
            else if (isRightBank == raft.IsRightBank && raft.isEmpty)
            {
                LoadOntoRaft();
            }
        }
    }

    public string[] Diet()
    {
        return diet;
    }

    public virtual void EatAnimation()
    {

    }

}
