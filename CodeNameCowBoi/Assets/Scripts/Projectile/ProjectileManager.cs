using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    //Projectile pool 
    public GameObject projectilePrefab;
    public int poolSize = 10;
    private GameObject[] projectiles;
    private int currentProjectile = 0;


    //Randomise rate
    [SerializeField]float randomIntervalMax = 1f; 
    [SerializeField] float randomIntervalMin = -1f;
    private float randomTime = 0;

    //target player
    private GameObject player;
    string playerTag = "Player";
    private Transform target;

    void Start()
    {
        projectiles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectiles[i] = obj;
        }

        //Random interval
        randomTime = Random.Range(randomIntervalMin, randomIntervalMax);
        InvokeRepeating("SpawnProjectile", randomTime, 1);

        //find player
        player = GameObject.FindGameObjectWithTag(playerTag);
        target = player.transform;
    }
   
    public GameObject SpawnProjectile()
    {
        
        //obj.transform.rotation = new Quaternion(transform.rotation.x + 1, transform.rotation.y, transform.rotation.x, transform.rotation.w);
        GameObject obj = projectiles[currentProjectile];
        obj.transform.position = transform.position;

        if (player != null) //can it find the player object?
        { 
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y;
            obj.transform.LookAt(targetPosition);
        }

        obj.SetActive(true);
        currentProjectile++;
        if (currentProjectile >= poolSize)
        {
            currentProjectile = 0;
        }
        return obj;
    }
}
