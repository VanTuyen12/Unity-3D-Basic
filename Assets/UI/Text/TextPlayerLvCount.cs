using System;
using UnityEngine;

public class TextPlayerLvCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        this.textPro.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}
