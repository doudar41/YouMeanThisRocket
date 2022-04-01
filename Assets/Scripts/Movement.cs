using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float addToBoost = 300f, rotateBoost = 2f;
    [SerializeField] ParticleSystem thrust; 
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
        float inputForce = Input.GetAxis("Vertical");
        if (inputForce != 0)
        {
            
            float thrustBoost = inputForce * Time.deltaTime * addToBoost;

            rb.AddRelativeForce(0,thrustBoost,0);

            thrust.startLifetime = inputForce * 0.1f;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
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
