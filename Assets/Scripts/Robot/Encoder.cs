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
        //return extraRotations + distance / 360.0;
        return distance / 360.0;
    }
}
