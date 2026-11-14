using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas infoCanvas;
    public GameObject sceneloader;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3(0,0,-100);
        Camera.main.transform.LookAt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
