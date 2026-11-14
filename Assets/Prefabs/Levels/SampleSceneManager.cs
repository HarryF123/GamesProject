using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneManager : MonoBehaviour
{
    Transform playerpos;
    public GameObject player;
    public GameObject enemy;

    void Start()
    {
      Camera.main.transform.position = new Vector3(0,0,-100);

      SpawnPlayer();
      playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
      Camera.main.transform.position = new Vector3(playerpos.position.x,playerpos.position.y,-100);
      Camera.main.transform.LookAt(playerpos.position);
    }

    void SpawnPlayer()
    {
        GameObject go = GameObject.Instantiate(player,new Vector3(0,5,0),transform.rotation);
    }

    void SpawnEnemy()
    {
        GameObject go = GameObject.Instantiate(enemy,new Vector3(10,5,0),transform.rotation);
    }
}
