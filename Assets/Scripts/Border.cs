using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    bool inPlace = true, firstMessage = false;
    GameBase gameBase;
    [SerializeField] float timeToSpentOutside;

    private void Start()
    {
        gameBase = FindObjectOfType<GameBase>();
        Invoke("TimeDelay",5f);
    }

    private void OnTriggerExit(Collider collision)
    {
        gameBase.MessageText(true, "You started your journey to distant stars", Color.red, 5f); 
        StartCoroutine(CrossBorderTimer());
        inPlace = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(!firstMessage)
        {
           return;
        }
        gameBase.MessageText(true,"Oh, you're back", Color.red, 5f);
        StopCoroutine(CrossBorderTimer());
        inPlace = true;
    }

    IEnumerator CrossBorderTimer()
    {
        yield return new WaitForSeconds(timeToSpentOutside);
        if (!inPlace)
        {
            gameBase.LoadGameScene(gameBase.activeGameLevel, true);
        }
    }

    void TimeDelay()
    {
        firstMessage = true;
    }

}
