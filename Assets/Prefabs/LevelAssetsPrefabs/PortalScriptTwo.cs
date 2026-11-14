using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalScriptTwo : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer unlit;
    public SpriteRenderer lit;

    public GameObject sceneloader;
    public Canvas prompt;

    void Start(){
        prompt.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        unlit.sortingLayerName="Layer 1";
        lit.sortingLayerName="Layer 1";
        lit.sortingOrder=0;
        unlit.sortingOrder=0;
    }

    // Update is called once per frame
    void Update()
    {

      if(player == null){
        player = GameObject.FindGameObjectWithTag("Player");
      }

      //Debug.Log("Range to Player: "+(transform.position - player.transform.position).sqrMagnitude);
      if((transform.position - player.transform.position).sqrMagnitude < 9){
        prompt.gameObject.SetActive(true);
        unlit.enabled = false;
        unlit.sortingLayerName="Layer 1";
        lit.sortingLayerName="Layer 1";
        lit.sortingOrder=0;
        unlit.sortingOrder=0;
        if((Input.GetKeyDown(KeyCode.E)) || (Input.GetKeyDown(KeyCode.Return)))
        {
          TeleportToHome();
        }
      }else{
        prompt.gameObject.SetActive(false);
        unlit.enabled = true;
        unlit.sortingLayerName="Layer 1";
        lit.sortingLayerName="Layer 1";
        lit.sortingOrder=0;
        unlit.sortingOrder=0;
      }
    }

    void TeleportToHome()
    {
        sceneloader.GetComponent<SceneChange>().LoadHome();
    }
}
