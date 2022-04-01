using System.Collections;
using System.Collections.Generic;
using UnityEngine;using TMPro;
using UnityEngine.SceneManagement;

public class GameBase : MonoBehaviour
{
    [SerializeField]  GameObject rocket;
    [SerializeField]  Transform spawnPoint;
    public int activeGameLevel;
    [SerializeField] TextMeshProUGUI messageText;


    void Start()
    {
        activeGameLevel = SceneManager.GetActiveScene().buildIndex;
        if (rocket != null)
        {
            Instantiate(rocket, spawnPoint);
        }
        messageText.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame


    public void LoadGameScene(int scene)
    {
        StartCoroutine(WaitToReload(scene));
    }
    IEnumerator WaitToReload(int scene)
    {
        yield return new WaitForSeconds(2f);
        if (SceneManager.sceneCount > scene)
        {
            SceneManager.LoadScene(scene);
        }   
        else SceneManager.LoadScene(0);
    }
}
