using System;
using UnityEngine;

public abstract class SliderHp : SliderAbstract
{
    protected virtual void FixedUpdate()
    {
        this.UpdateSlider();    
    }

    protected virtual void UpdateSlider()
    {
        slider.value = GetValue();
    }

    protected abstract float GetValue();

}
