using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject enemy; // single game object to be duplicated
    public int numEnemies = 5; // number of objects in the array
    public float radius = 10f; // radius of the perimeter

    private void Start()
    {
        GameObject[] objectArray = new GameObject[numEnemies];
        Vector3 center = transform.position; // center point

        for (int i = 0; i < numEnemies; i++)
        {
            // Calculate the position of each duplicated object along the perimeter
            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            Vector3 position = center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;


            // Instantiate a new game object and store it in the array
            objectArray[i] = Instantiate(enemy, position, Quaternion.identity);
        }
    }


}
