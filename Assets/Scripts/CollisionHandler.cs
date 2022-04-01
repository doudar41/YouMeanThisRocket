using System.Collections;
using UnityEngine;
using Cinemachine;


public class CollisionHandler : MonoBehaviour
{
    GameBase gameBase;
    Rigidbody rb;
    [SerializeField]CinemachineVirtualCamera vcam;
    [SerializeField] ParticleSystem explosion;
    bool isAlive = true;

    private void Awake()
    {
        gameBase = FindObjectOfType<GameBase>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isAlive) return;

        string x = collision.gameObject.tag;
        switch (x)
        {
            case "Obstacle":
                DoOnCollision("Obstacle");
                break;
            case "Mineral":
                gameBase.AddScore();
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
                explosion.Play();
                MeshRenderer[] x = gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer i in x)
                {
                    i.enabled = false;
                }
                gameBase.LoadGameScene(gameBase.activeGameLevel, true);

                isAlive = false;
                break;
            case "Finish":

                foreach (Transform child in transform)
                {
                    child.gameObject.transform.parent = transform;
                }
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rb.freezeRotation = true;
                vcam.m_Follow = null;
                gameBase.LoadGameScene(gameBase.activeGameLevel+1, false);
                //GetComponent<Movement>().enabled = false;
                isAlive = false;
                break;
            default:
                break;
        }
        
    }


}
