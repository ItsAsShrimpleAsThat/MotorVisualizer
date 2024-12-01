using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandRunner : MonoBehaviour
{
    public XRPDrivetrain m_xrpDrivetrain;
    public Command activeCommand;
    public TMP_InputField distInput, speedInput;
    public Button start, stop;
    public TMP_Dropdown cmdOptions;

    private void FixedUpdate()
    {
        if (activeCommand != null)
        {
            if (activeCommand.isFinished())
            {
                activeCommand.end(false);
                activeCommand = null;
                m_xrpDrivetrain.setLeftMotor(0.0);
                start.interactable = true;
                stop.interactable = false;

                return;
            }
            activeCommand.execute();
        }
    }

    public void ScheduleCommand(Command command)
    {
        activeCommand = command;
        activeCommand.initialize();
    }

    //button
    public void RunDriveCommand()
    {
        if (activeCommand != null)
        {
            activeCommand.end(true);
        }

        double distance = double.Parse(distInput.text);
        double speed = double.Parse(speedInput.text);

        Command selectedCmd;

        if(cmdOptions.value == 0)
        {
            selectedCmd = new EncoderStop(m_xrpDrivetrain, distance, speed);
        }
        else
        {
            selectedCmd = new DriveDistance(m_xrpDrivetrain, distance, speed);
        }

        ScheduleCommand(selectedCmd);

        start.interactable = false;
        stop.interactable = true;
    }

    public void StopCommand()
    {
        start.interactable = true;
        stop.interactable = false;

        activeCommand.end(true);
        activeCommand = null;

        m_xrpDrivetrain.setLeftMotor(0.0);
    }
}