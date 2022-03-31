using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBase : MonoBehaviour
{
    [SerializeField]
    GameObject rocket;
    Transform spawnPoint;
    void Start()
    {
        if (rocket != null)
        {
            Instantiate(rocket, spawnPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
