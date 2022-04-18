using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] float rotationSpeed, warningDistance, dividingTime;
    [SerializeField] Vector3 movementDirection;
    Vector3 startPosition;
    float distanceToPlayer, movementFactor =0 ;
    const float tau = Mathf.PI * 2;

    GameBase gameBase;
    
    private void Start()
    {
        startPosition = transform.position;
        gameBase = FindObjectOfType<GameBase>();
    }


    void Update()
    {
        SineMoveTo();
        ApproachingPlayer();
        
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }

    private void ApproachingPlayer()
    {
        distanceToPlayer = Mathf.Abs(gameBase.PlayerTransform().position.x - transform.position.x);

        if (distanceToPlayer < warningDistance)
        {
            float volumeWarning = 1 - (distanceToPlayer * 0.1f);
            Debug.Log(volumeWarning);
        }
    }

    private void SineMoveTo()
    {
        Vector3 offset = movementDirection * movementFactor;
        transform.position = startPosition + offset;

        float cycles = Time.time * dividingTime;

        movementFactor = Mathf.Sin(cycles * tau);
    }
}
