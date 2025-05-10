using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        //
    }
    protected virtual void LoadComponents()
    {
        //For
    }

    protected virtual void Start()
    {
        //
    }
}
