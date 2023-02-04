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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float xMovement = movement.ReadValue<Vector3>().x;
        float zMovement = movement.ReadValue<Vector3>().z;
        float jumpMovement = movement.ReadValue<Vector3>().y;
        Debug.Log(xMovement);



        Debug.Log(zMovement);


        float forceSize = 0.1f;
        

        float newXPos = transform.localPosition.x + xOffset * xMovement;
        float newZPos = transform.localPosition.z + zOffset * zMovement;

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if(jumpMovement == 1f)
        {
            rb.AddForce(Vector3.up, ForceMode.Force);
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
