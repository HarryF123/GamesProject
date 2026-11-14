using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer chestRenderer;
    public Sprite opened;
    public Sprite closed;
    public bool open;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(player == null){
        player = GameObject.FindGameObjectWithTag("Player");
      }
      //Debug.Log((transform.position - player.transform.position).sqrMagnitude);
      if(ArenaManager.enemiesDead == true){
      if(((transform.position - player.transform.position).sqrMagnitude < 9) && Input.GetKeyDown(KeyCode.Return) && open != true || ((transform.position - player.transform.position).sqrMagnitude < 9) && Input.GetKeyDown(KeyCode.E) && open != true)
      {
        Open();
        open = !open;
      }
      else if(((transform.position - player.transform.position).sqrMagnitude < 9) && Input.GetKeyDown(KeyCode.Return) && open == true || ((transform.position - player.transform.position).sqrMagnitude < 9) && Input.GetKeyDown(KeyCode.E) && open == true)
      {
        Close();
        open = !open;
      }
     }
    }

    void Open()
    {
      //Debug.Log("Open Sesame");
      chestRenderer.sprite = opened;
      //add something to player inventory
    }

    void Close()
    {
      //Debug.Log("Close Pls");
      chestRenderer.sprite = closed;
    }

}
