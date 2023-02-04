using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float lanuchVelocity = 1f;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * lanuchVelocity);
    }
}
