using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Transform playerpos;
    public GameObject player;
    public GameObject bruiser;

    void Start()
    {
        Camera.main.transform.position = new Vector3(0,0,-100);
        SpawnPlayer();
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //SpawnBruiser();
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

    void SpawnBruiser()
    {
      GameObject go = GameObject.Instantiate(bruiser,new Vector3(0,1,0),transform.rotation);
    }
}
