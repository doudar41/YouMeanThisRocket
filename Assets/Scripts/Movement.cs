using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float addToBoost = 300f, rotateBoost = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GivenRocketABoost();
        RotateRocket();
    }


    private void GivenRocketABoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
           
            Vector3 thrustBoost = Vector3.up * Time.deltaTime * addToBoost;

            rb.AddRelativeForce(thrustBoost);
        }
    }

    private void RotateRocket()
    {
        rb.freezeRotation = true;
        Vector3 rot = Vector3.forward * Time.deltaTime * rotateBoost;

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(rot);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(-rot);
        }
        rb.freezeRotation = false;
    }
}
