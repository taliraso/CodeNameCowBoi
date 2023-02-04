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
    public float forceSize = 200;


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

        float newXPos = transform.localPosition.x + xOffset * xMovement;
        float newZPos = transform.localPosition.z + zOffset * zMovement;

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        //Restrict jump to only when in original position


        if (jumpMovement == 1f && transform.position.y < 1.05)
        {
            Debug.Log("weJumpin");
            rb.AddForce(Vector3.up*forceSize, ForceMode.Force);
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
