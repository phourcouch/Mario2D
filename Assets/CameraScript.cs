using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    public GameObject Mario;
    public float smoothTime = 0.6f;
    public float xVelocity = 0.0f;
    public float yVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Mario.transform.position.x, Mario.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float newXPosition = Mathf.SmoothDamp(transform.position.x, Mario.transform.position.x, ref xVelocity, smoothTime);
        float newYPosition = Mathf.SmoothDamp(transform.position.y, Mario.transform.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
    }

}
