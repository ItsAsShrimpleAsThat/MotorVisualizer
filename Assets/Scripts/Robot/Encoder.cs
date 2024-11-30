using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encoder : MonoBehaviour
{
    public double distance;
    public int extraRotations;

    public double previousRotation;

    public double getRotations()
    {
        return distance / 360.0;
    }
}
