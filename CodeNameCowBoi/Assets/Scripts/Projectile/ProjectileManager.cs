using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int poolSize = 10;
    private GameObject[] projectiles;
    private int currentProjectile = 0;

    void Start()
    {
        projectiles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectiles[i] = obj;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetProjectile();
        }
    }
    public GameObject GetProjectile()
    {
        GameObject obj = projectiles[currentProjectile];
        obj.SetActive(true);
        currentProjectile++;
        if (currentProjectile >= poolSize)
        {
            currentProjectile = 0;
        }
        return obj;
    }
}
