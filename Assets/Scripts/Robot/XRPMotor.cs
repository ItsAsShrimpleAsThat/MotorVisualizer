using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPMotor : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public Rigidbody rb;
    public bool isInverted = false;

    public Encoder encoder;
    public void set(double speed)
    {
        this.speed = (float)speed;   
    }

    public void setInverted(bool inverted)
    {
        this.isInverted = inverted;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float angularVelocity = speed * maxSpeed * (isInverted ? -1 : 1);
        rb.angularVelocity = rb.transform.right * angularVelocity;

        // update encoder- we can't use the rotor's rotation because unity wraps object rotations to 0 when >360
        if(encoder != null)
        {
            if ((rb.transform.localEulerAngles.x - encoder.previousRotation) * Mathf.Sign(angularVelocity) < -180)
            {
                encoder.extraRotations += System.Math.Sign(angularVelocity);
            }

            double distance360 = rb.transform.localEulerAngles.x;
            encoder.distance = distance360;
            encoder.previousRotation = rb.transform.localEulerAngles.x;
        }
    }
}
