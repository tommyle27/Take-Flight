using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour {
    public GameObject plane;
    private Vector3 offset = new Vector3(0.0f, 5.0f, -15.0f);
    private Quaternion angle = new Quaternion(0.05f, 0.0f, 0.0f, 1.0f);

    // Update is called once per frame
    void Update() {
        transform.position = plane.transform.position + offset;
        transform.rotation = angle;
    }
}
