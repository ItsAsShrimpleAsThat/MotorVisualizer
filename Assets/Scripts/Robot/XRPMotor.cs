using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPMotor : MonoBehaviour
{
    public float maxSpeed;
    public float idealSpeed;
    public float realSpeed;
    public Transform rotorTransform;
    public float rotation;
    public bool isInverted = false;
    public float motorSpeedRandomness;
    public float motorAcceleration;
    public float minSpeedToRotate;

    public Encoder encoder;
    public void set(double speed)
    {
        this.idealSpeed = Mathf.Clamp((float)speed, -1.0f, 1.0f);   
    }

    public void setInverted(bool inverted)
    {
        this.isInverted = inverted;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(idealSpeed) < minSpeedToRotate)
        {
            realSpeed = 0;
        }
        else
        {
            realSpeed = Mathf.MoveTowards(realSpeed, idealSpeed, motorAcceleration);
        }
        rotation += Mathf.Clamp(realSpeed, -1.0f, 1.0f) * (maxSpeed + Random.Range(-motorSpeedRandomness, motorSpeedRandomness)) * (isInverted ? -1 : 1);
        rotorTransform.localRotation = Quaternion.Euler(rotation, 0.0f, 0.0f);

        // update encoder- we can't use the rotor's transform rotation because unity wraps object rotations to 0 when >360
        if(encoder != null)
        {
            encoder.distance = rotation;
        }
    }
}
