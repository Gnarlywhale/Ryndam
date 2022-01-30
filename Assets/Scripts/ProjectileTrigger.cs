using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    public Projectile ProjectilePrefab;
    public Transform LaunchPos;
    int arcDir = 1;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Shoot!");
            Projectile projectile = Instantiate(ProjectilePrefab, LaunchPos.position, LaunchPos.rotation);
            projectile.arcDir = arcDir;
            arcDir = arcDir * -1 ;
        }
    }
}
