using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //SceneManager.LoadSceneAsync(2);    
        }
    }
}
