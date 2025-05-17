using System;
using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    bool isLeftClick = false;
    bool isRightClick = false;

    protected virtual void Update()
    {
        this.CheckRightClick();
    }

    protected virtual void CheckRightClick()
    {
        this.isLeftClick = Input.GetMouseButton(0);
        this.isRightClick = Input.GetMouseButton(1);
    }

    public virtual bool IsLeftClick()
    {
        return this.isLeftClick;
    }
    
    public virtual bool IsRightClick()
    {
        return this.isRightClick;
    }
}
