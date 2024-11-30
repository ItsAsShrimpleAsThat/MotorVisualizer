using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class XRPDrivetrain : MonoBehaviour
{
    [SerializeField] private XRPMotor leftMotor;
    [SerializeField] private XRPMotor rightMotor;

    [SerializeField] private Encoder leftEncoder;
    [SerializeField] private Encoder rightEncoder;

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

    public double getLeftEncoder()
    {
        return leftEncoder.getRotations();
    }

    public double getRightEncoder()
    {
        return rightEncoder.getRotations();
    }

    public double getEncoderAverages()
    {
        return (getLeftEncoder() + getRightEncoder()) / 2.0;
    }

    public double test()
    {
        return leftEncoder.previousRotation;
    }
}
