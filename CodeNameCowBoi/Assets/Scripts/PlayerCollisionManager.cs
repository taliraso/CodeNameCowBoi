using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{

    public int health = 3;
    public GameObject floor;


    //Score
    public ScoreManager scoreManager;
    public int scoreValue = 10;

    public GameObject[][] projectilePoolObject;
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
        if (collision.gameObject.tag == "Projectile") 
        {
            collision.gameObject.SetActive(false);
            health -= 1;
            //scoreManager.UpdateScore(scoreValue);
            scoreManager.score ++ ;
        }
           
       

        //if (health < 1)
        //{
        //    Destroy(gameObject);
        //}
    }
}
