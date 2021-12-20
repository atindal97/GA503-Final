using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlane : MonoBehaviour
{
    public Rigidbody rigidbody = null;
    public float forwardVel = 0f;

    public bool useGravity = false;

    [Header("Velocity")]
    public float initialVelocity = 50f;
    public float maxSpeed = 30f;

    [Header("Acceleration")]
    public float accel = 10f;
    public float braking = 5f;
    public bool canReverse = false;

    [Header("Rotation")]
    public float yawSpeed = 15f;
    public float pitchSpeed = 15f;
    public float rollSpeed = 15f;

    private float halfSpeed = 0f;
    private bool active = false;

    private void Start()
    {
        if(useGravity) { rigidbody.useGravity = true; }

        //Lock our cursor to the screen.
        Cursor.lockState = CursorLockMode.Locked;

        //Set an intial forward velocity
        rigidbody.velocity = transform.forward * initialVelocity;

        //below half-speed we simulate lack of "lift" aka falling
        halfSpeed = maxSpeed * 0.5f;

        //Late activate to deal with bad mouse delta input
        StartCoroutine(ActivateAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            float thrust = Input.GetAxis("Vertical");

            //Thurst
            if (thrust > 0)
            {
                forwardVel += thrust * accel * Time.deltaTime;
                UpdateVelocity();
            }
            else if (thrust < 0)
            {
                forwardVel += thrust * braking * Time.deltaTime;
                UpdateVelocity();
            }
            else
            {
                forwardVel = Vector3.Dot(rigidbody.velocity, transform.forward);
            }

            //Turn
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime);
            //Roll
            transform.Rotate(Vector3.forward, rollSpeed * -Input.GetAxis("Mouse X") * Time.deltaTime);
            //Pitch
            transform.Rotate(Vector3.right, pitchSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime);
        }
    }

    //Needed to deal with bad mouse Input in the first few frames
    private IEnumerator ActivateAfterDelay()
    {
        for(int i = 0; i < 5; i++)
        {
            yield return null;
        }

        active = true;
    }

    private void UpdateVelocity()
    {
        if (useGravity)
        {
            float fallVelocity = 0;
            if (rigidbody.velocity.y < 0) { fallVelocity = -rigidbody.velocity.y; }

            //Clamp the forward velocity
            forwardVel = Mathf.Clamp(forwardVel, canReverse ? -(maxSpeed + fallVelocity) : 0, maxSpeed + fallVelocity);

            rigidbody.velocity = transform.forward * forwardVel;

            rigidbody.velocity += (Mathf.Clamp01(1 - forwardVel / halfSpeed) * Physics.gravity);
        }
        else
        {
            forwardVel = Mathf.Clamp(forwardVel, canReverse ? -maxSpeed : 0, maxSpeed);
            rigidbody.velocity = transform.forward * forwardVel;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Reset our forward when we hit the ground (often zeroes out)
        forwardVel = Vector3.Dot(rigidbody.velocity, transform.forward);
    }
}
