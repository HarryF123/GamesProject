using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
  public Animator animator;
  public float transitionTime = 1f;

  void update()
  {

  }

  public void LoadMenu()
  {
    StartCoroutine(LoadLevel(0));
  }

  public void LoadHome()
  {
    StartCoroutine(LoadLevel(1));
  }

  public void LoadThroneArena()
  {
    StartCoroutine(LoadLevel(2));
  }

  public void LoadKingsGarden()
  {
    StartCoroutine(LoadLevel(3));
  }

  IEnumerator LoadLevel(int levelIndex)
  {
    animator.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(levelIndex);
  }
}
