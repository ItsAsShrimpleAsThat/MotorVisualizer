using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShuffleboardUI : MonoBehaviour
{
    public XRPDrivetrain m_driveSubsystem;
    public TMP_Text encoderDistance, error, pOutput, iOutput, dOutput;

    private void Update()
    {
        encoderDistance.text = m_driveSubsystem.getLeftEncoder().ToString();
        error.text = (PIDOutputs.setpoint - m_driveSubsystem.getLeftEncoder()).ToString();
        pOutput.text = PIDOutputs.pOutput.ToString();
        iOutput.text = PIDOutputs.iOutput.ToString();
        dOutput.text = PIDOutputs.dOutput.ToString();
    }
}
