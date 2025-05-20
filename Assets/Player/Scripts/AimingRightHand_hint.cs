using UnityEngine;

public class AimingRightHand_hint : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(16.021f, 1.2712f, 13.164f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
