using Unity.VisualScripting;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public Camera ChessCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChessCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChessCam.gameObject.SetActive(false);    
        }
    }
}
