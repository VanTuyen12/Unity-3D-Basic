using System;
using UnityEngine;

public abstract class TxtLevel : Text3DAbstract
{
    protected virtual void FixedUpdate()
    {
        UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        textPro.text = GetLevel();
    }

    protected abstract string GetLevel();
}
