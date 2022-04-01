using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    bool inPlace = true;

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("You start your journey to distant stars");
        StartCoroutine(CrossBorderTimer());
        inPlace = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Oh, your back");
        StopCoroutine(CrossBorderTimer());
        inPlace = true;
    }

    IEnumerator CrossBorderTimer()
    {
        yield return new WaitForSeconds(5f);
        if (!inPlace)
        {
            SceneManager.LoadScene(0);
        }
    }
}
