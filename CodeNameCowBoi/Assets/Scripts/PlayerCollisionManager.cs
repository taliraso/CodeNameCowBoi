using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{

    public int health = 3;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject)
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
           
       

        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
