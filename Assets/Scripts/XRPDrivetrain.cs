using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPDrivetrain : MonoBehaviour
{
    [SerializeField] private XRPMotor leftMotor;
    [SerializeField] private XRPMotor rightMotor;
    
    public void setLeftMotor(double speed)
    {
        leftMotor.set(speed);
    }
}
