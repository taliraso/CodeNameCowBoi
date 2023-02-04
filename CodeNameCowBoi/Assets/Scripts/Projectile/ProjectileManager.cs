using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    /// <summary>
    /// Zach - Fix the null ref pooling issues plz
    /// 
    /// </summary>
    //Projectile pool 
    //public GameObject projectilePrefab;
    public GameObject[] projectileArray;
    private int arrayIndex = 0;

    public int poolSize = 10;
    private GameObject[] projectiles;
    private int currentProjectile = 0;
    private GameObject[][] projectilePools;


    //Randomise rate
    [SerializeField] float randomIntervalMax = 10f; 
    [SerializeField] float randomIntervalMin = 0f;
    private float randomTime = 0.1f;

    //target player
    private GameObject player;
    string playerTag = "Player";
    private Transform target;
    public float projectileOffset = 1;
    void Start()
    {
        arrayIndex = projectileArray.Length;
        projectilePools = new GameObject[projectileArray.Length][];

        projectiles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectileArray[Random.Range(0,arrayIndex)]);
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
    private void Update()
    {
        
    }

    public GameObject SpawnProjectile()
    {
        
        //obj.transform.rotation = new Quaternion(transform.rotation.x + 1, transform.rotation.y, transform.rotation.x, transform.rotation.w);
        GameObject obj = projectiles[currentProjectile];
        obj.transform.position = transform.position;

        if (player != null) //can it find the player object?
        { 
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y + projectileOffset;
            obj.transform.LookAt(targetPosition);
            obj.SetActive(true);
        }
        currentProjectile++;

        if (currentProjectile >= poolSize)
        {
            currentProjectile = 0;
        }
        return obj;
    }
}
