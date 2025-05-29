using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMoving : SaiMonoBehaviour
{
   [SerializeField]List<Point> points ;

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadPoints();
   }
   
   public virtual Point GetPoint(int index)//Tim Kiem bang Index
   {
      return this.points[index];
   }
   
   public virtual void LoadPoints()
   {
      if (this.points.Count > 0 ) return;

      foreach (Transform child in transform)
      {
         Point point = child.GetComponent<Point>();
         
         this.points.Add(point);
      }
      Debug.Log(transform.name + " :LoadPoints " ,gameObject);
   }
}
