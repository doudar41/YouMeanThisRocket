using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    const string obstacle = "Obstacle";


    private void OnCollisionEnter(Collision collision)
    {
        string x = collision.gameObject.tag;
        switch (x)
        {
            case obstacle:
                RestartLevel();
                break;
            case "Mineral":
                Debug.Log("Add score");
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }


    void RestartLevel()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
