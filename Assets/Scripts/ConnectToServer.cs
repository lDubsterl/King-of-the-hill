using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviour
{
    void Start()
    {
    }

    void OnConnectoToMaster()
    {
        SceneManager.LoadScene("Menu");
    }
}
