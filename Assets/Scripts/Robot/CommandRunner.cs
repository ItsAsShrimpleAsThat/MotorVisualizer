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

    private void FixedUpdate()
    {
        if (activeCommand != null)
        {
            if (activeCommand.isFinished())
            {
                activeCommand.end(false);
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

        ScheduleCommand(new DriveDistance(m_xrpDrivetrain, double.Parse(distInput.text), double.Parse(speedInput.text)));

        start.interactable = false;
        stop.interactable = true;
    }

    public void StopCommand()
    {
        start.interactable = true;
        stop.interactable = false;

        activeCommand.end(true);
        activeCommand = null;

        Debug.Log("If this prints, i will not kill myself");
        m_xrpDrivetrain.setLeftMotor(0.0);
    }
}
