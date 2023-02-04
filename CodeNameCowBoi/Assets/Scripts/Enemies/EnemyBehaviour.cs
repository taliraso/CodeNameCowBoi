using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private GameObject player;
    string playerTag = "Player";
    
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag(playerTag);
    }
    private void Update()
    {
        if(player != null) //can it find the player object?
        {
           
            this.transform.LookAt(player.transform); //i'm mr meeseeks look at me!

        }
    }
}
