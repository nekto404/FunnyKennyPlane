using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllRevert : MonoBehaviour {

    public GameControllerScript GameController;
    public Image LLArrow;
    public Image LBArrow;
    public Image RLArrow;
    public Image RBArrow;
    public Sprite ArrowUp;
    public Sprite ArrowDown;

    public void RevertControll()
    {
        if (GameController.RevertControll())
        {
            LLArrow.sprite = ArrowDown;
            LBArrow.sprite = ArrowUp;
            RLArrow.sprite = ArrowUp;
            RBArrow.sprite = ArrowDown;
        }
        else
        {
            LLArrow.sprite = ArrowUp;
            LBArrow.sprite = ArrowDown;
            RLArrow.sprite = ArrowDown;
            RBArrow.sprite = ArrowUp;
        }
    }
}
