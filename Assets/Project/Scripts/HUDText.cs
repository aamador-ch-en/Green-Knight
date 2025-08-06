using TMPro;
using UnityEngine;

public class HUDText : MonoBehaviour
{

    public string LandName;
    public TextMeshProUGUI LandElement;
    public string GoalName;
    public TextMeshProUGUI GoalElement;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO get strings from xml file using a specific UID/nametag 
        LandElement.text = LandName;
        GoalElement.text = GoalName;
    }

    void GetDialogue()
    { 

    }
}
