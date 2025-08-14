using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject PlayerInventory;
    public GameObject GameMngr;
    public bool chessGame;
    void Start()
    {
        Vector3 test = PlayerObject.transform.position;
        chessGame = true;
    }
    void Update()
    {
        float distance;
        distance = Vector3.Distance(PlayerObject.transform.position, transform.position);
        if (distance < 4 && chessGame)
        {
            chessGame = false;
            LoadChessScen();
        }
        if (distance > 10 && !chessGame)
        {
            chessGame = true;
        }
    }
    void LoadChessScen()
    {
        GameMngr.SendMessage("LoadChess");
    }
    
}
