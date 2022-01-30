using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float transitionTime;
    private Camera cam;
    private Vector3 startPos;
    private Vector3 newPos;
    private char direction;
    private bool isMoving;
    private bool moveTrigger;
    private float elapsedTime;
    private float movementInc;

    //private Vector2 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        isMoving = false;
        moveTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        triggerMovementKeys();
    }

    private void FixedUpdate()
    {
        MoveCamera(direction);
    }

    public void triggerMovementKeys()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = 'n';
            moveTrigger = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = 's';
            moveTrigger = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 'e';
            moveTrigger = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = 'w';
            moveTrigger = true;
        }
    }
    
    public void MoveCamera(char direction)
    {
        if (moveTrigger == true)
        {
            if (isMoving == false)
            {
                Debug.Log("move start");
                elapsedTime = 0;
                isMoving = true;
                startPos = transform.position;
            } else
            {
                elapsedTime += Time.fixedDeltaTime;
                Debug.Log(elapsedTime);
                Debug.Log("moving");
                if (elapsedTime < transitionTime)
                {
                    movementInc = Time.fixedDeltaTime / transitionTime;
                    Debug.Log(movementInc);
                    if (direction == 'n')
                    {
                        newPos = new Vector3(transform.position.x, transform.position.y + (12 * movementInc), transform.position.z);
                    }
                    else if (direction == 'e')
                    {
                        newPos = new Vector3(transform.position.x + (20 * movementInc), transform.position.y, transform.position.z);
                    }
                    else if (direction == 's')
                    {
                        newPos = new Vector3(transform.position.x, transform.position.y - (12 * movementInc), transform.position.z);
                    }
                    else if (direction == 'w')
                    {
                        newPos = new Vector3(transform.position.x - (20 * movementInc), transform.position.y, transform.position.z);
                    }
                    transform.position = newPos;
                }
                    if (elapsedTime >= transitionTime)
                    {
                    Debug.Log(elapsedTime);
                    Debug.Log("moving");
                    if (direction == 'n')
                    {
                        newPos = new Vector3(startPos.x, startPos.y + 12, startPos.z);
                    }
                    else if (direction == 'e')
                    {
                        newPos = new Vector3(startPos.x + 20, startPos.y, startPos.z);
                    }
                    else if (direction == 's')
                    {
                        newPos = new Vector3(startPos.x, startPos.y - 12, startPos.z);
                    }
                    else if (direction == 'w')
                    {
                        newPos = new Vector3(startPos.x - 20, startPos.y, startPos.z);
                    }
                    transform.position = newPos;
                    isMoving = false;
                    moveTrigger = false;
                }
            }
   
        }
    }
}
