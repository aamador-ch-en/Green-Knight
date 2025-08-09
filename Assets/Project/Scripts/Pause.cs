using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameScreen;
    public TextMeshProUGUI AreaText;
    public TextMeshProUGUI MainText;
    public TextMeshProUGUI RetryText;
    public delegate void PauseGame();
    public static PauseGame onPauseGame;
    PauseIndex SelectedIndex = PauseIndex.back;
    public GameObject switchSFX;
    void Start()
    {
        SelectedIndex = PauseIndex.back;
        HighlightSelect();
    }
    void Update()
    {
        bool isPaused = pauseScreen.activeSelf;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                pauseScreen.SetActive(false);
                gameScreen.SetActive(true);
            }
            else
            {
                pauseScreen.SetActive(true);
                gameScreen.SetActive(false);
            }
            switchSFX.GetComponent<AudioSource>().Play();
        }
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (SelectedIndex == PauseIndex.back)
                {
                    SelectedIndex = PauseIndex.retry;
                }
                else
                {
                    SelectedIndex--;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (SelectedIndex == PauseIndex.retry)
                {
                    SelectedIndex = PauseIndex.back;
                }
                else
                {
                    SelectedIndex++;
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                //TODO add Yes or No confirmation when clicking on Return and Retry
                switch (SelectedIndex)
                {
                    case PauseIndex.back:
                        pauseScreen.SetActive(false);
                        gameScreen.SetActive(true);
                        break;
                    case PauseIndex.quit:
                        SceneManager.LoadSceneAsync(0);
                        break;
                    case PauseIndex.retry:
                        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                        pauseScreen.SetActive(false);
                        gameScreen.SetActive(true);
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                HighlightSelect();
                switchSFX.GetComponent<AudioSource>().Play();
            }
        }
    }

    void HighlightSelect()
    {
        switch (SelectedIndex)
        {
            case PauseIndex.back:
                AreaText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                MainText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                RetryText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                break;
            case PauseIndex.quit:
                AreaText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                MainText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                RetryText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                break;
            case PauseIndex.retry:
                AreaText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                MainText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                RetryText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                break;
        }
    }
    
    enum PauseIndex
    {
        back,
        quit,
        retry
    }
}
