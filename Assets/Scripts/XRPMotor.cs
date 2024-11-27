using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPMotor : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public Rigidbody rb;
    public bool isInverted = false;
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
        rb.angularVelocity = new Vector3(speed * maxSpeed * (isInverted ? -1 : 1), 0, 0);
    }
}
