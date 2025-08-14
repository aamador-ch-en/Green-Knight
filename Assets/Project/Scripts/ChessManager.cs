using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChessManager : MonoBehaviour
{
    public GameObject playerKing;
    public GameObject enemyKing;
    public GameObject GameOver;
    public GameObject Victory;
    public Camera ChessCam;
    bool isGameOngoing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameOngoing = true;
        ChessCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerKing.activeSelf && isGameOngoing)
        {
            isGameOngoing = false;
            GameOver.SetActive(true);
            StartCoroutine("WaitForScreenToEnd");
        }
        if (!enemyKing.activeSelf && isGameOngoing)
        {
            isGameOngoing = false;
            Victory.SetActive(true);
            StartCoroutine("WaitForScreenToEnd");
        }
    }
    IEnumerator WaitForScreenToEnd()
    {
        yield return new WaitForSeconds(3f);
        if (GameOver.activeSelf)
        {
            SceneManager.LoadSceneAsync(0);
        }
        if (Victory.activeSelf)
        {
            SceneManager.UnloadSceneAsync(1);
        }
    }
}
