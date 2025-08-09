using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Main : MonoBehaviour
{
    public GameObject soundScreen;
    public GameObject mainScreen;
    public GameObject switchSound;
    public GameObject startSound;
    public TextMeshProUGUI StartText;
    public TextMeshProUGUI SoundText;
    public TextMeshProUGUI LeaveText;
    public TextMeshProUGUI MusVol;
    public TextMeshProUGUI SFXVol;
    public TextMeshProUGUI MusTxt;
    public TextMeshProUGUI SFXTxt;
    bool isMusicSelect;
    AudioSource switchSource;
    public AudioMixer masterMix;
    MainIndex SelectedIndex = MainIndex.start;
    void Start()
    {
        SelectedIndex = MainIndex.start;
        HighlightSelect();
        isMusicSelect = true;
        switchSource = switchSound.GetComponent<AudioSource>();
                    
    }
    void Update()
    {
        bool isSound = soundScreen.activeSelf;
        if (isSound)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switchSource.Play();
                soundScreen.SetActive(false);
                mainScreen.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                isMusicSelect = !isMusicSelect;
                switchSource.Play();
            }
            if (isMusicSelect)
            {
                MusVol.color = new Color(0.3333f, 1.0f, 1.0f, 1.0f);
                SFXVol.color = new Color(0.3333f, 1.0f, 0.3333f, 1.0f);
                MusTxt.color = new Color(0.3333f, 1.0f, 1.0f, 1.0f);
                SFXTxt.color = new Color(0.3333f, 1.0f, 0.3333f, 1.0f);
            }
            else
            {
                SFXVol.color = new Color(0.3333f, 1.0f, 1.0f, 1.0f);
                MusVol.color = new Color(0.3333f, 1.0f, 0.3333f, 1.0f);
                SFXTxt.color = new Color(0.3333f, 1.0f, 1.0f, 1.0f);
                MusTxt.color = new Color(0.3333f, 1.0f, 0.3333f, 1.0f);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (isMusicSelect)
                {
                    int mVol = Convert.ToInt16(MusVol.text);
                    if (mVol != 0)
                    {
                        mVol -= 5;
                    }
                    MusVol.SetText(mVol.ToString());
                    float volume = -80+80*mVol/100;
                    masterMix.SetFloat("Music", volume);
                }
                else
                {
                    int sVol = Convert.ToInt16(SFXVol.text);
                    if (sVol != 0)
                    {
                        sVol -= 5;
                    }
                    SFXVol.SetText(sVol.ToString());
                    float volume = -80+80*sVol/100;
                    masterMix.SetFloat("SFX", volume);
                    switchSource.Play();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (isMusicSelect)
                {
                    int mVol = Convert.ToInt16(MusVol.text);
                    if (mVol != 100)
                    {
                        mVol += 5;
                    }
                    MusVol.SetText(mVol.ToString());
                    float volume = -80+80*mVol/100;
                    masterMix.SetFloat("Music", volume);
                }
                else
                {
                    int sVol = Convert.ToInt16(SFXVol.text);
                    if (sVol != 100)
                    {
                        sVol += 5;
                    }
                    SFXVol.SetText(sVol.ToString());
                    float volume = -80+80*sVol/100;
                    masterMix.SetFloat("SFX", volume);
                    switchSource.Play();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (SelectedIndex == MainIndex.start)
                {
                    SelectedIndex = MainIndex.quit;
                }
                else
                {
                    SelectedIndex--;
                }
                HighlightSelect();
                switchSource.Play();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (SelectedIndex == MainIndex.quit)
                {
                    SelectedIndex = MainIndex.start;
                }
                else
                {
                    SelectedIndex++;
                }
                HighlightSelect();
                switchSource.Play();
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                //TODO add Yes or No confirmation when clicking on Return and Retry
                switch (SelectedIndex)
                {
                    case MainIndex.start:
                        startSound.GetComponent<AudioSource>().Play();
                        SceneManager.LoadSceneAsync(2);
                        break;
                    case MainIndex.sound:
                        switchSource.Play();
                        mainScreen.SetActive(false);
                        soundScreen.SetActive(true);
                        float volumeMusic;
                        masterMix.GetFloat("Music", out volumeMusic);
                        MusVol.text = (volumeMusic * 100 / 80 + 100).ToString();

                        float volumeSFX;
                        masterMix.GetFloat("SFX", out volumeSFX);
                        SFXVol.text=(100 + volumeSFX * 100 / 80).ToString();
                        break;
                    case MainIndex.quit:
                        Debug.Log("Application.Quit()");
                        //Application.Quit();
                        break;
                }
            }
        }
    }

    void HighlightSelect()
    {
        switch (SelectedIndex)
        {
            case MainIndex.start:
                StartText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                SoundText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                LeaveText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                break;
            case MainIndex.sound:
                StartText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                SoundText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                LeaveText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                break;
            case MainIndex.quit:
                StartText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                SoundText.color = new Color(0.3333f, 1.0f, 0.3333f,1.0f);
                LeaveText.color = new Color(0.3333f, 1.0f, 1.0f,1.0f);
                break;
        }
    }
    
    enum MainIndex
    {
        start,
        sound,
        quit
    }
}
