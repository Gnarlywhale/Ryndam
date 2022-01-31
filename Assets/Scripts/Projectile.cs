using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;
    private Vector2 targetPos;
    private Vector2 startPos;
    public float arcHeight = 1;
    public int arcDir;
    public float damage;
private Vector3 _initialPosition;
private List<Vector3> _allPositions;
private int _counter;
private Vector3 target;
    private Vector3 offset = new Vector3(4f,4f,0f);
    float DistanceToTarget = 1f;
// private void Start()
// {
//     target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     _initialPosition = transform.position;
//     _allPositions = new List<Vector3>(100);
//     Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     for (var i = 0; i < 10; i++)
//     {
//         var newPosition = (Vector2)CubicCurve(_initialPosition, _initialPosition + offset * arcDir, _initialPosition + offset * arcDir,
//             target, (float)i / 10);
//         _allPositions.Add(newPosition);
//     }
//     //_allPositions[_allPositions.Count - 1] = target;
// }


private void Start() {
    GameObject topCP = GameObject.Find("TopControlPoint");
    GameObject botCP = GameObject.Find("BotControlPoint");
     target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    _initialPosition = transform.position;
    _allPositions = new List<Vector3>(100);
    Vector2 newPosition; 
    // calcCP();
    for (var i = 0; i < 10; i++)
    {
        if (arcDir == 1) {
 newPosition = (Vector2)CubicCurve(_initialPosition, topCP.transform.position,topCP.transform.position,
            target, (float)i / 10);

        } else {
             newPosition = (Vector2)CubicCurve(_initialPosition, botCP.transform.position,botCP.transform.position,
            target, (float)i / 10);

        }
        
        _allPositions.Add(newPosition);
    }
    //_allPositions[_allPositions.Count - 1] = target;
}
float t = 0;
float curveAngle  = 45f;
private Vector2 calcCP(){

    Vector2 res = new Vector2();
    Vector2 lineVector = target - _initialPosition;
    float angle = Vector2.Angle(lineVector,Vector2.right);
    Debug.Log(angle);
    float hypo = Vector2.Distance(target,_initialPosition);
    Debug.Log(hypo);

    float pointLength = Mathf.Cos(curveAngle) * hypo;
    Debug.Log(pointLength);


    // Calculate the angle

    // 
    return res;
}

private void Update()
{
   
    if (_counter < _allPositions.Count)
    {
        transform.position = Vector3.MoveTowards(transform.position, _allPositions[_counter], Time.deltaTime * 10);
        if (Vector3.Distance(transform.position, _allPositions[_counter]) < DistanceToTarget) _counter++;
    } else {
        if (transform.position != target){
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 10);
        }else {
            Destroy(gameObject);
        }
    }
    if (Vector2.Distance(transform.position, target) == 0) Destroy(gameObject);

    // Debug.Log();
}

private Vector3 CubicCurve(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float t)
{
    return (((-start + 3 * (control1 - control2) + end) * t + (3 * (start + control2) - 6 * control1)) * t +
            3 * (control1 - start)) * t + start;
}

//since _initialPosition is set on start, the drawn curve is from (0,0,0) if the code is not executed

//     private void Start() {
//         startPos = transform.position;
//         Debug.Log(startPos);
//         targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
//         // Destroy(gameObject,5f);
//     }
// private void Update() {
//     // float step = speed * Time.deltaTime;
//     //      transform.position= Vector2.MoveTowards(transform.position, target, step);
//     float x0 = startPos.x;
// 		float x1 = targetPos.x;
// 		float dist = x1 - x0;
// 		float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
// 		float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
// 		float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist) * arcDir;
//         // arcDir = arcDir * -1;
// 		Vector2 nextPos = new Vector2(nextX, baseY + arc);
		
// 		// Rotate to face the next position, and then move there
// 		transform.rotation = LookAt2D(nextPos - (Vector2)transform.position);
// 		transform.position = nextPos;



// 		// Do something when we reach the target
// 		if (nextPos == targetPos) Arrived();
//      }
     static Quaternion LookAt2D(Vector2 forward) {
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
     private void OnCollisionEnter2D(Collision2D other) {
         Debug.Log("Collision");
         if (other.gameObject.tag != "Player" && other.gameObject.tag != "PCProjectile"){
             if (other.gameObject.tag == "Enemy"){
                 PusherController pusher = other.gameObject.GetComponent<PusherController>();
                 Debug.Log("I hit "+gameObject.name+" for "+damage);
                 pusher.DamagePusher(damage);
             }
Destroy(gameObject);
         }
         
     }
     void Arrived() {
		Destroy(gameObject);
	}
}
