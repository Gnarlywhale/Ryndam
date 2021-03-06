using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCController : MonoBehaviour
{
    public class PlayerStats{
        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth{
            get { return _curHealth;}
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth);}
        }
        public void Init(){
            curHealth = maxHealth;
        }

    }
    public PlayerStats stats = new PlayerStats();
    public int assignedMB = 0;
    public float speed;
    private bool moving = false;
    private bool onPath = false;
    private bool lookingRight = true;

    

    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    List<Vector2> trackedPath = new List<Vector2>();
    [SerializeField]
    private StatusIndicator statusIndicator;
    // Start is called before the first frame update
    void Start()
    {
        stats.Init();
        if (statusIndicator == null) {
            Debug.LogError("No status indicator referenced on "+gameObject.name);
        }else {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collison");
        if(other.gameObject.name != "Right" && other.gameObject.tag != "PCProjectile" && other.gameObject.tag != "Player"){
            moving = false;
            onPath = false;
        }
    }
    public void DamagePlayer(int damage){
        stats.curHealth -= damage;
        if (stats.curHealth <= 0){
            GameMaster.KillPlayer(this);
            // Handle player death somehow?
        }
    }
    void FixedUpdate() {
        Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        if (lookDir.x < 0 && lookingRight)
        {
            lookingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (lookDir.x > 0 && !lookingRight)
        {
            lookingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        //transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (moving && trackedPath.Count > 0 ){
        // Travel to start location
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, trackedPath[0],step);
        // if (!onPath && transform.position == trackedPath[0]){
        //     onPath = true;
        //     trackedPath.RemoveAt(0);
        // }
        
        if ((Vector2)transform.position == trackedPath[0]){
            trackedPath.RemoveAt(0);
        }
        
        // Debug.Log(trackedPath[0]);

        // 
        // Reset the path
    } else{
            moving = false;
            onPath = false;
// trackedPath = new List<Vector3>();
        }
    }
    // Update is called once per frame
    void Update()
    {
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    Debug.Log(trackedPath.Count);
    // Debug.Log("Mouse Position");
    // Debug.Log(Input.mousePosition);
    if (Input.GetMouseButtonDown(assignedMB)){
        trackedPath = new List<Vector2>();
    }
    if (Input.GetMouseButton(assignedMB)){
        //Collect path to follow
        trackedPath.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // Debug.Log("MB down!");

    
    }
    if (Input.GetMouseButtonUp(assignedMB)){
        moving = true;
  
    }
    
        
    
    }
}
