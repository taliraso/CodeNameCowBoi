using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    Rigidbody rb;
    [SerializeField] float xOffset = 0.005f;
    [SerializeField] float zOffset = 0.005f;
    public float forceSize = 300;
    public float dashSpeed = 2; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Our current x and z 
        float currentXPos = transform.localPosition.x;
        float currentZPos = transform.localPosition.z;
        float currentYPos = transform.localPosition.y;

        //are we pressing button? 1 and -1 Yes, 0 No 
        float xMovement = movement.ReadValue<Vector3>().x;
        float zMovement = movement.ReadValue<Vector3>().z;
        float dashMovement = movement.ReadValue<Vector3>().y;

        //Moving the player
        float newXPos = currentXPos + xOffset * xMovement * dashSpeed;
        float newZPos = currentZPos + zOffset * zMovement * dashSpeed;

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if (dashMovement == 1)
        {
            dashSpeed = 2;
        }
        else
        {
            dashSpeed = 1;
        }

    }

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }
}
