using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    public Projectile ProjectilePrefab;
    public Transform LaunchPos;
    public float Damage = 10;
    int arcDir = 1;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Shoot!");
            Projectile projectile = Instantiate(ProjectilePrefab, LaunchPos.position, LaunchPos.rotation);
            projectile.arcDir = arcDir;
            projectile.damage = Damage;
            arcDir = arcDir * -1 ;
        }
    }
}
