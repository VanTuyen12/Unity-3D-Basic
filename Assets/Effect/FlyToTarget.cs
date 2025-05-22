using System;
using UnityEngine;

public class FlyToTarget : SaiMonoBehaviour
{
   protected Transform target;
   protected float speed = 27f;

   private void Update()
   {
      Flying();
   }

   public virtual void SetTarget(Transform target)
   {
      this.target = target;
      transform.parent.LookAt(this.target);//LookAt: GameObject của bạn xoay và "nhìn" về phía một điểm hoặc một đối tượng khác.
   }
   
   protected virtual void Flying()
   {
      if (target == null) return;
      transform.parent.Translate(Vector3.forward * (speed * Time.deltaTime));//Translate: di chuyen theo duong thang trc mat
   }
}
