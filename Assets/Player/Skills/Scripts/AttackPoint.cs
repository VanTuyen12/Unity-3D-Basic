using UnityEngine;

public class AttackPoint : SaiMonoBehaviour
{
   protected override void Reset()
   {
      base.Reset();
      transform.localPosition = new Vector3(0.749f, 1.387f, 0.04f);
   }
}
