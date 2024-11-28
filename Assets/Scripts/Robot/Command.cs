using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public abstract void execute();
    public abstract void initialize();

    private void Start()
    {
        initialize();
    }

    void FixedUpdate()
    {
        execute();
    }
}
