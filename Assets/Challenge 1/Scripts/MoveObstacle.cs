using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float wallSpeed;

    // Update is called once per frame
    void FixedUpdate() {
        transform.Translate(transform.forward * wallSpeed * Time.fixedDeltaTime);
    }
}
