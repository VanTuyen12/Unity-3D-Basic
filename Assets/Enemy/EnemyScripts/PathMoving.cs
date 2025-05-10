using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = "Path_0";
    }
}
