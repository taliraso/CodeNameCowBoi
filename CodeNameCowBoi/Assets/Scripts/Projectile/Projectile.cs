using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float lanuchVelocity = 1f; // how fast the projectile will shoot

    public float projectileBoundry = 10f; //position limit that the projectile can go 

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * lanuchVelocity);

        if(transform.position.z > projectileBoundry)
        {
            gameObject.SetActive(false);
        }
    }
}
