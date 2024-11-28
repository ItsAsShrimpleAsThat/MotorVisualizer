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

    public void setRightMotor(double speed)
    {
        rightMotor.set(speed);
    }

    public void setBothMotors(double speed)
    {
        leftMotor.set(speed);
        rightMotor.set(speed);
    }
}
