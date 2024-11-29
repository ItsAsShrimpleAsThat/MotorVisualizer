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

    public double iZone = double.PositiveInfinity;

    private double setpoint = 0;
    private double error = 0;
    private double previousError;
    private double accumulatedError = 0;

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

        return kp * error + ki * accumulatedError + kd * errorDerivative;
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
}
