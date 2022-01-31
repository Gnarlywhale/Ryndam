using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static void KillPlayer(PCController player){
        Destroy(player);
    }
     public static void KillEnemy(GameObject player){
        Destroy(player);
    }
}
