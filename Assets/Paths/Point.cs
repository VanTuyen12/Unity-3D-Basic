using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : SaiMonoBehaviour
{
   [SerializeField] protected Point nextPoint;
   public Point NextPoint => nextPoint;
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadNextPoint();
   }

   protected virtual void LoadNextPoint()
   {
      if (this.nextPoint != null) return;
      
      int siblingIndex = this.transform.GetSiblingIndex();
      if (siblingIndex +1 < transform.parent.childCount)
      {
         Transform nextSibling = transform.parent.GetChild(siblingIndex + 1);
         this.nextPoint = nextSibling.GetComponent<Point>();
      }
      
      //Debug.Log(transform.name + " :siblingIndex " + siblingIndex);
     // Debug.Log(transform.name + " :LoadNextPoint " , gameObject);
   }
}
