using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherController : MonoBehaviour
{
    float stepDelay = 1.5f;
    float timer = 0;
    public float wallDistThresh = 4f;
    public float pcDistThresh = 4f;
    public float stepSize = 1;

    public float speed = 3f;
    string state = "march";
    bool moving = false;
    Vector2 targetPos;
    Vector2 travelDir = -Vector2.right;
    bool stepping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
    }
    private void FixedUpdate() {
        // Standard walk loop - walk to the end of the row and turn around.
        // If see PC and close, rush forward and attack
        // Double damage? when attacked from behind
        RaycastHit2D hit = Physics2D.Raycast(transform.position, travelDir);
        switch (state){
            case "march":               

                    if(hit.collider != null){
                        
                        // Close to a player? Go fuck em up
                        if(hit.collider.tag == "PC" && hit.distance < wallDistThresh) 
                        {
                            state = "agro";
                            return;
                        }
                        // Hitting a wall? Turn around
                        // Debug.Log( Vector2.Distance(hit.collider.transform.position, transform.position) );
                        
                        if(hit.collider.tag == "Terrain" && Vector2.Distance(hit.collider.transform.position, transform.position) <= wallDistThresh){
                            
travelDir = -travelDir;
                        } 
                    }
                     if (timer > stepDelay && !moving){
                         
                        // Take a step
                        moving = true;
                        targetPos = (Vector2)transform.position + travelDir * stepSize;
                        
                     }
                     if (moving){
                         // If the step is done, stop moving and chill.
                         if ((Vector2)transform.position == targetPos) {
                            moving = false;
                            timer = 0;
                            return;
                         }
                         //Keep moving to complete the step.
                         float step = speed * Time.deltaTime;

                        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
                     }
                    
                    
                
            break;
        }
        

    }
}
