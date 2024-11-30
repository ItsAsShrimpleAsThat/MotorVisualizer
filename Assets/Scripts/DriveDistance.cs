using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveDistance : Command
{
    private XRPDrivetrain m_driveSubsystem;
    private double distance;
    private double maxSpeed;
    
    public DriveDistance(XRPDrivetrain subsystem, double distance, double maxSpeed)
    {
        m_driveSubsystem = subsystem;
        this.distance = distance;
        this.maxSpeed = maxSpeed;
    }

    // Called when the command is initially scheduled.
    public override void initialize() {}

    // Called every time the scheduler runs while the command is scheduled.
    public override void execute()
    {
        m_driveSubsystem.setLeftMotor(maxSpeed);       
    }
}
