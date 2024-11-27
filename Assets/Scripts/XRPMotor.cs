using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPMotor : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public Rigidbody rb;
    public void set(double speed)
    {
        this.speed = (float)speed;   
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
        rb.AddRelativeTorque(new Vector3(speed * maxSpeed, 0, 0));
    }
}
