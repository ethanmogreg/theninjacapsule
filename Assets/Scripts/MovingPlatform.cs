using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //This script was my original attempt at making a moving platform script. I could not get it to work as I wanted due to using a CharacterController instead of a Rigidbody.

    // Start is called before the first frame update
    public Vector3[] points;
    public Vector3 velocity;
    private Vector3 previous;
    public int pointNumber = 0;
    private Vector3 currentTarget;
    public float tolerance;
    public float speed;
    public float delayTime;
    private float delayStart;
    public bool automatic;



    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    private void FixedUpdate()
    {
        velocity = ((transform.position - previous) / Time.deltaTime);
        previous = transform.position;
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.normalized.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }

    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];

    }
}
