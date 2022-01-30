using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMelee : MonoBehaviour
{
    public GameObject LeftBoxCutter;
    public GameObject RightBoxCutter;
    private Animator anim;
    public GameObject Wielder;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            Debug.Log("Melee!");
            anim.SetBool("isAttacking",true);
            // LeftBoxCutter.transform.RotateAround(Wielder.transform.position, Vector3.up, 20 * Time.deltaTime);
            // 
            // Projectile projectile = Instantiate(ProjectilePrefab, LaunchPos.position, LaunchPos.rotation);
            // projectile.arcDir = arcDir;
            // arcDir = arcDir * -1 ;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("isAttacking",false);
        }
    }

}
