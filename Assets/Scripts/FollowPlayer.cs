using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{

    // create a public variable to assign a player type gameObject to script
    public GameObject player;

    // create a private vaiable to store offSet value for the camera position, and angle
    private Vector3 ThirdPerson = new Vector3(0.0f, 6.0f, -9.0f);
    private Quaternion angle = new Quaternion(0.15f, 0.0f, 0.0f, 1.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // every frame, transform the cameras position to the players position
        transform.position = player.transform.position + ThirdPerson;
        transform.rotation = angle;

    }
}
