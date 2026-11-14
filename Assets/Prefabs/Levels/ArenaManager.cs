using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
  Transform playerpos;
  public GameObject player;
  public GameObject enemy;
  public GameObject bruiser;
  public GameObject sceneloader;
  public Transform circleTransform;

  public float radius;
  public int enemyWave;
  public int enemyNumber;

  public static bool enemiesDead;

  void Start()
  {
      enemiesDead = false;
      enemyWave = 1;
      radius = 4.0f;
      Camera.main.transform.position = new Vector3(0,0,-100);
      SpawnPlayer();
      playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      SpawnWave(enemyWave);
  }

  // Update is called once per frame
  void Update()
  {
    enemyNumber = EnemyAI.count + BruiserAI.count;
    if(enemyNumber <= 0)
    {
      enemiesDead = true;
    }
    Camera.main.transform.position = new Vector3(playerpos.position.x,playerpos.position.y,-100);
    Camera.main.transform.LookAt(playerpos.position);
  }

  void SpawnPlayer()
  {
      GameObject go = GameObject.Instantiate(player,new Vector3(0,5,0),transform.rotation);
  }

  void SpawnWave(int numToSpawn){
    for(int i = 0; i<=numToSpawn * 2; i++){
      Invoke("SpawnEnemy", 3.0f);
    }
    Invoke("SpawnBruiser", 4.0f);
  }

  void SpawnEnemy()
  {
    Instantiate(enemy, circleTransform.position + Random.insideUnitSphere * radius, Quaternion.identity);
    enemyNumber++;
  }

  void SpawnBruiser()
  {
    Instantiate(bruiser, circleTransform.position + Random.insideUnitSphere * radius, Quaternion.identity);
    enemyNumber++;
  }

  public void EnemyKilled()
  {
    if(enemyNumber == 0){
      enemyWave++;
    }
  }
}
