using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberSpace : MonoBehaviour {

    public int Number;
    public GameObject[] Cells;

    public void Show()
    {  
        for (int i=0; i < Cells.Length; i++)
        {
            
            if (Number.ToString().Length > i)
            {
                Cells[i].SetActive(true);
                Cells[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/UI/Numbers/number" + Number.ToString().Substring(i, 1));
            }
            else
            {
                Cells[i].SetActive(false);
            }
        }
    }
}
