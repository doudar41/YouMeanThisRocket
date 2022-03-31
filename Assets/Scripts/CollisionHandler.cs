using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    const string obstacle = "Obstacle";


    private void OnCollisionEnter(Collision collision)
    {
        string x = collision.gameObject.tag;
        switch (x)
        {
            case obstacle:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
