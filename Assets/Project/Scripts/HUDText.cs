using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HUDText : MonoBehaviour
{

    public string LandName;
    public TextMeshProUGUI LandElement;
    public string GoalName;
    public TextMeshProUGUI GoalElement;

    public int enemiesLeft;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO get strings from xml file using a specific UID/nametag 
        LandElement.text = LandName;
        GoalElement.text = "Best " + enemiesLeft.ToString() + " saxons";
        enemiesLeft = 3;
    }

    void GetDialogue()
    {

    }
    void UpdateSaxon()
    {
        enemiesLeft -= 1;
        GoalElement.text = "Best " + enemiesLeft.ToString() + " saxons";
    }
}
