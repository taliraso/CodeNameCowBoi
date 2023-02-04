using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private GameObject player;
    string playerTag = "Player";
    private Transform target; 
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        target = player.transform;
    }

    private void Update()
    {
        if(player != null) //can it find the player object?
        {
            //this.transform.LookAt(player.transform); //i'm mr meeseeks look at me!
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }
}
