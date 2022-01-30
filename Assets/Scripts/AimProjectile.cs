using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimProjectile : MonoBehaviour
{
   private Transform aimTransform;
   private void Awake() {
       aimTransform = transform.Find("Aim");
   }
   private void Update() {
    //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 aimDirection = (mousePosition - transform.position).normalized;
    // float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)* Mathf.Rad2Deg;
    // aimTransform.eulerAngles = new Vector3(0,0,angle);

   }
  
}
