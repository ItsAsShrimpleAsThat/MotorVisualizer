using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Command
{
    public virtual void execute()
    {

    }
    public virtual void initialize()
    {

    }

    public virtual bool isFinished()
    {
        return false;
    }

    public virtual void end(bool interrupted)
    {

    }
}
