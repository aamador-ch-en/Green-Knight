using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject PlayerObject;
    void Start()
    {
        //Vector3 test = transform.position;
        //Debug.Log(test.x);
        //Debug.Log(test.y);
        //Debug.Log(test.z);
         Vector3 test = PlayerObject.transform.position;
        Debug.Log(test.x);
        Debug.Log(test.y);
        Debug.Log(test.z);
    }
    void Update()
    {
        float distance;
        distance = Vector3.Distance(PlayerObject.transform.position, transform.position);
        Debug.Log(distance.ToString());
    }
    
}
