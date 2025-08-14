using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject PlayerInventory;
    public GameObject GameMngr;
    public GameObject ThisObject;
    void Start()
    {
        Vector3 test = PlayerObject.transform.position;
    }
    void Update()
    {
        float distance;
        distance = Vector3.Distance(PlayerObject.transform.position, transform.position);
        if (distance < 4)
        {
            GameMngr.SendMessage("LoadChess");
            //If win we won, if lost... They robbed us and fled
            Destroy(ThisObject);
        }
    }
    
}
