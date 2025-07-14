using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    // create variable to store speed of your killer (drunk driver type shit)
    public float TrafficSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the traffic/bus every second
        //  had to inverse forward vector so bus actaully drives towards player 
        // bus' forward vector is fockin facing away from the camera originally and rotated that mf
        // to face you, therefore type shit - forward vector still faces away from camera 
        // so you gotta inverse that shit
     transform.Translate(-transform.forward * Time.deltaTime * TrafficSpeed);   
    }
}
