using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ModalWindow : MonoBehaviour
{

    public Text PText;
    public Text PTitle;
    public int Index;
    public int Price;
    public menuConttroller MenuConttroller;

    public void Show()
    {
       gameObject.SetActive(true); 
    }

    public void SetText(String title, String text)
    {
        PText.text = text;
        PTitle.text = title;
    }

    public void CloseButton()
    {
        gameObject.SetActive(false);
    }

    public void OkButton()
    {
        MenuConttroller.Upgrade(Index,Price);
        gameObject.SetActive(false);
    }
}
