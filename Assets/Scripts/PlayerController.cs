using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    // vehicle variables
    private float CarSpeed = 20.0f;
    private float TurnSpeed = 50.0f;
    private float HorizontalInput;
    private float ForwardInput;

    // set up shit for the cameras
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public KeyCode ChangePOV;


    // for local multiplayer a string ID is needed to determine whos input is whos so no two people control the same player
    public string InputID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // assign HorizontalInput variable value of Horizontal value from keyboard 'a' and 'd' input
        HorizontalInput = Input.GetAxis("Horizontal" + InputID);
        // assign ForwardInput variable value the Vertical value from keyboard 'w' and 's'
        ForwardInput = Input.GetAxis("Vertical" + InputID);

        // every frame we are going to move the flippin car forward cuz we never look back
        transform.Translate(Vector3.forward * CarSpeed * Time.deltaTime * ForwardInput);

        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);
        

        // if key is pressed to change pov than disable current can and enable other
        if (Input.GetKeyDown(ChangePOV))
        {
            firstPersonCam.enabled = !firstPersonCam.enabled;
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
        }
    }
}
