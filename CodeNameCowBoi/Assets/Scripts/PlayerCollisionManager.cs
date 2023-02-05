using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionManager : MonoBehaviour
{

    public int health = 3;
    public GameObject floor;
    public Image[] hearts;
    public Sprite fullHeart;
    public GameObject[][] projectilePoolObject;

    public ScoreManager scoreManager;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;   
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(health == 0)
        {
           gameOver = true;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile") 
        {
            
            collision.gameObject.SetActive(false);
            scoreManager.score++;
        }
        if (collision.gameObject.tag == "Carrot")
        {
            collision.gameObject.SetActive(false);
            health -= 1;

        }   
       

        //if (health < 1)
        //{
        //    Destroy(gameObject);
        //}
    }
}
