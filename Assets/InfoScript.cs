using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public Canvas infoCanvas;
    public Canvas menuCanvas;

    void Start()
    {
      infoCanvas.gameObject.SetActive(false);
    }

    public void HideInfo()
    {infoCanvas.gameObject.SetActive(false);}

    public void ShowInfo()
    {infoCanvas.gameObject.SetActive(true);}

    public void ShowMenu()
    {menuCanvas.gameObject.SetActive(true);}

    public void HideMenu()
    {menuCanvas.gameObject.SetActive(false);}
}
