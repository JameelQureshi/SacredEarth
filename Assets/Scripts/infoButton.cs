using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class infoButton : MonoBehaviour
{

    public Image img;
    public bool isImgOn;

    void Start()
    {
        img.enabled = false;
        isImgOn = false;
        GetComponent<Button>().onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (isImgOn == true) {

            img.enabled = false;
            isImgOn = false;


        } else {

            img.enabled = true;
            isImgOn = true;

         }
    }
}