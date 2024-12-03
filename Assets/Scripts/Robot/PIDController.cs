using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------ lil credit thing -----
// Much of this code was stolen from WPILib
// https://github.com/wpilibsuite/allwpilib/blob/main/wpimath/src/main/java/edu/wpi/first/math/controller/PIDController.java
public class PIDController
{
    public double kp;
    public double ki;
    public double kd;

    public double pOutput { get; private set; }
    public double iOutput { get; private set; }
    public double dOutput { get; private set; }

    public double iZone = double.PositiveInfinity;

    private double setpoint = 0;
    private double error = 0;
    private double previousError;
    public double accumulatedError = 0;

    private double minIntegral = -1.0;
    private double maxIntegral = 1.0;
    
    public PIDController(double kp, double ki, double kd)
    {
        this.kp = kp;
        this.ki = ki;
        this.kd = kd;
    }

    public double calculate(double measurement)
    {
        previousError = error;
        error = setpoint - measurement;

        double errorDerivative = (error - previousError) / Time.fixedDeltaTime;
        Debug.Log(errorDerivative * kd);
        // if error is extremely large, reset the accumulated error to limit overshooting from a huuuge integral error ("windup") if iZone is set
        if(System.Math.Abs(error) > iZone)
        {
            accumulatedError = 0.0;
        }    
        else
        {
            //prevent integral from going outside of minIntegral / ki < integral < maxIntegral / ki to prevent windup
            accumulatedError = System.Math.Clamp(accumulatedError + error * Time.fixedDeltaTime,
                                                 minIntegral / ki,
                                                 maxIntegral / ki);
        }

        pOutput = kp * error;
        iOutput = ki * accumulatedError;
        dOutput = kd * errorDerivative;

        PIDOutputs.pOutput = pOutput;
        PIDOutputs.iOutput = iOutput;
        PIDOutputs.dOutput = dOutput;

        return pOutput + iOutput + dOutput;
    }

    public double calculate(double measurement, double setpoint)
    {
        this.setpoint = setpoint;
        return calculate(measurement);
    }

    public void setSetpoint(double setpoint)
    {
        this.setpoint = setpoint;
    }

    public void setPID(double p, double i, double d)
    {
        kp = p;
        ki = i;
        kd = d;
    }

    public void setPIDiz(double p, double i, double d, double iZone)
    {
        kp = p;
        ki = i;
        kd = d;
        this.iZone = iZone;
    }

    public void setIZone(double iZone)
    {
        this.iZone = iZone;
    }

    public void setiZoneToInfinity()
    {
        iZone = double.PositiveInfinity;
    }
}
