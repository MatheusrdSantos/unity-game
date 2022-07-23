using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 0.05f;
    private int direction = 1;
    public bool upwards = false;
    public float maxDistance = 4f;
    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector3 diractionVec = upwards ? new Vector3(0.0f, speed * direction, 0.0f) : new Vector3(speed * direction, 0.0f, 0.0f);
        Vector3 newPosition = transform.position + diractionVec;
        if ((initPos - newPosition).magnitude > maxDistance) {
            direction *= -1;
        } else {
            transform.position = newPosition;
        }
    }
}
