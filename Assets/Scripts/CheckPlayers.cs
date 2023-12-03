using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPlayers : NetworkBehaviour
{
    [SerializeField] Canvas deathCanvas;
    float timer = 0;

    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
            return;
        }


        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            deathCanvas.enabled = true;
            //enabled = false;
        }
    }

    public void BackToMainMenu()
    {
       // NetworkManager.singleton.StopHost();
        SceneManager.LoadScene(0);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }
}
