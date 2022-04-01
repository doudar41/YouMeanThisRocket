using System.Collections;
using System.Collections.Generic;
using UnityEngine;using TMPro;
using UnityEngine.SceneManagement;

public class GameBase : MonoBehaviour
{
    [SerializeField]  GameObject rocket;
    [SerializeField]  Transform spawnPoint;
    [SerializeField] ScoreManager dataContainer;
    GameObject player;

    public int activeGameLevel; 
    int score = 0;
    
    [SerializeField] TextMeshProUGUI levelText, messageText, scoreText;


    void Start()
    {
        score = dataContainer.score;
        scoreText.text = score.ToString() ;
        activeGameLevel = SceneManager.GetActiveScene().buildIndex;
        if (rocket != null)
        {
            player = Instantiate(rocket, spawnPoint);
        }
        levelText.text = SceneManager.GetActiveScene().name;
    }


    private void Update()
    {
        float t = Mathf.Sin(Time.time / 2f);
            float t1 = Time.time ;
        Debug.LogFormat("Sin: {0}, Time: {1}", t, t1);
   
  


    }


    public void LoadGameScene(int scene, bool loseWin)
    {
        if (loseWin)
        {
            messageText.enabled = true;
            messageText.color = Color.red;
            messageText.text = "This rock is too rocky";
        }
        else
        {
            messageText.enabled = true;
            messageText.color = Color.red;
            messageText.text = "Woah, I did it";
        }
        StartCoroutine(WaitToReload(scene));
    }
    IEnumerator WaitToReload(int scene)
    {
        dataContainer.score = score;
        yield return new WaitForSeconds(2f);
        if (SceneManager.sceneCount > scene)
        {
            SceneManager.LoadScene(scene);
        }   
        else SceneManager.LoadScene(0);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

    }

    public void MessageText( bool showMessage, string massage, Color color, float duration)
    {
        messageText.enabled = showMessage;
        messageText.color = color;
        messageText.text = massage;
        if(showMessage)
        {
            Invoke("CloseMessage", duration);
        }
    }

    void CloseMessage()
    {
        messageText.enabled = false;
    }


    public Transform PlayerTransform()
    {
        return player.transform;
    }

}
