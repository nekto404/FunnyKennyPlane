using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllRevert : MonoBehaviour
{

    public GameControllerScript GameController;
    public Image LLArrow;
    public Image LBArrow;
    public Image RLArrow;
    public Image RBArrow;
    public Sprite ArrowUp;
    public Sprite ArrowDown;

    void Start()
    {
        Init();
    }

    public void RevertControll()
    {
        if (GameController.RevertControll())
        {
            LLArrow.sprite = ArrowDown;
            LBArrow.sprite = ArrowUp;
            RLArrow.sprite = ArrowUp;
            RBArrow.sprite = ArrowDown;
            PlayerPrefs.SetInt("RevertControl", 1);
        }
        else
        {
            LLArrow.sprite = ArrowUp;
            LBArrow.sprite = ArrowDown;
            RLArrow.sprite = ArrowDown;
            RBArrow.sprite = ArrowUp;
            PlayerPrefs.SetInt("RevertControl", 0);
        }
    }

    void Init()
    {
        if (PlayerPrefs.HasKey("RevertControl"))
        {
            if (PlayerPrefs.GetInt("RevertControl") == 1)
            {
                RevertControll();
            }
        }
        else
        {
            PlayerPrefs.SetInt("RevertControl",0);
        }
    }
}
