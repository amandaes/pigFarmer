using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform objectToFollow;

    public float moveSpeed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            Vector2 targetPos = Vector2.Lerp(transform.position, objectToFollow.position, Time.deltaTime * moveSpeed);
            transform.position = new Vector3(targetPos.x, targetPos.y, -10);
        }
    }
}
