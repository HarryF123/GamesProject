using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScrip : MonoBehaviour
{
    public GameObject sceneloader;
    public void StartGame()
    {
      sceneloader.GetComponent<SceneChange>().LoadHome();
    }
}
