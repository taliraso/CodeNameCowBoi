using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //This script is to determine how many enemies we will have in the scene
    public GameObject[] enemyObjArray;
    public int numEnemies = 0;

    private void Start()
    {
        numEnemies = enemyObjArray.Length; // Count enemies in array entry
        
        for (int i=0; i < numEnemies; i++)
        {
            //spawn at a place
        }
        
    }

}
