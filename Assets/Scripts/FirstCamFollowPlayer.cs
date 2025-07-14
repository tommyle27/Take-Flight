using UnityEngine;

public class FirstCamFollowPlayer : MonoBehaviour
{

    // create a public variable to assign a player type gameObject to script
    public GameObject player;
    private Vector3 FirstPerson = new Vector3(0.0f, 2.0f, 0.1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + FirstPerson;
    }
}
