using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
    public GameObject[] prefabs; // The prefabs to be spawned in the pool
    public int poolSize; // The size of the pool
    public float minSpawnInterval = 1.0f; // The minimum time between object spawns
    public float maxSpawnInterval = 2.0f; // The maximum time between object spawns

    private GameObject[][] pools; // The pools of objects
    private int[] currentIndices; // The current indices of the pools
    private float timeUntilNextSpawn; // The time until the next object spawn

    //target player
    private GameObject player;
    string playerTag = "Player";
    private Transform target;
    public float projectileOffset = 1;

    private void Start()
    {
        pools = new GameObject[prefabs.Length][];
        currentIndices = new int[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new GameObject[poolSize];
            currentIndices[i] = 0;
            for (int j = 0; j < poolSize; j++)
            {
                pools[i][j] = Instantiate(prefabs[i]);
                pools[i][j].SetActive(false);
            }
        }

        //find player
        player = GameObject.FindGameObjectWithTag(playerTag);
        target = player.transform;

        timeUntilNextSpawn = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            int randomIndex = Random.Range(0, prefabs.Length);

            if (player)
            {
                GameObject obj = pools[randomIndex][currentIndices[randomIndex]];
                Vector3 objRotation = obj.transform.rotation.eulerAngles;
                objRotation.x = 0;
                objRotation.z = 0;
                
                obj.transform.position = transform.position;
                obj.transform.LookAt(target);
                obj.SetActive(true);
            }

            currentIndices[randomIndex]++;
            if (currentIndices[randomIndex] >= poolSize)
            {
                currentIndices[randomIndex] = 0;
            }

            timeUntilNextSpawn = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}
