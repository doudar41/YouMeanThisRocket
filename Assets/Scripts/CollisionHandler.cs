using System.Collections;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    GameBase gameBase;

    private void Awake()
    {
        gameBase = FindObjectOfType<GameBase>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        string x = collision.gameObject.tag;
        switch (x)
        {
            case "Obstacle":
                DoOnCollision("Obstacle");
                break;
            case "Mineral":
                Debug.Log("Add score");
                Destroy(collision.gameObject);
                break;
            case "Finish":
                DoOnCollision("Finish");
                break;
            default:
                break;
        }
    }

    void DoOnCollision(string callUI)
    {

        switch(callUI)
        {
            case "Obstacle":
                gameBase.LoadGameScene(gameBase.activeGameLevel);
                Destroy(gameObject);
                break;
            case "Finish":
                gameBase.LoadGameScene(gameBase.activeGameLevel+1);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                GetComponent<Rigidbody>().freezeRotation = true;
                GetComponent<Movement>().enabled = false;

                break;
            default:
                break;
        }
        
        
        //call UI
    }





}
