using UnityEngine;

public class LookAtPlayer : SaiMonoBehaviour
{
   [SerializeField]protected Transform playerCamera;

   protected override void LoadComponents()
   {
       base.LoadComponents();
       this.LoadCamera();
   }

   protected virtual void LoadCamera()
   {
       if (playerCamera != null) return;
       playerCamera = GameObject.Find("ThirdPersonCamera").transform;
       Debug.Log(transform.name + " :LoadPlayerCamera",gameObject);
   }

   void Update()
    {
        transform.LookAt(playerCamera);//quay theo huong camera
        transform.rotation =Quaternion.Euler(0,transform.rotation.eulerAngles.y + 180,0);
    }
}
