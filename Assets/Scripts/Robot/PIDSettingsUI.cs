using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PIDSettingsUI : MonoBehaviour
{
    public TMP_InputField pInput, iInput, dInput, iZoneInput;
    public Toggle useIZone;
    void Start()
    {
        SetPIDConstants();
        ToggleIZoneInput();
    }
    public void SetPIDConstants()
    {
        Constants.kp = double.Parse(pInput.text);
        Constants.ki = double.Parse(iInput.text);
        Constants.kd = double.Parse(dInput.text);
        Constants.iZone = useIZone.isOn ? double.Parse(iZoneInput.text) : double.PositiveInfinity;
    }

    public void ToggleIZoneInput()
    {
        iZoneInput.interactable = useIZone.isOn;
    }
}
