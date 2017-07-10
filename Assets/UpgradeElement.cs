using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeElement : MonoBehaviour
{

    public GameObject[] Counter;
    public ModalWindow ModalWindowsWithVariants;
    public ModalWindow ModalWindowsWithOutVariants;
    public menuConttroller MainConttroller;
    public String UpgradeText;
    public String UpgradeTitleText;
    public String InfoText;
    public String InfoTitleText;
    public int UpgradeIndex;

    private int _value;

    public void SetValue(int newValue)
    {
        _value = newValue;
        for (int i = 0; i < _value; i++)
        {
            Counter[i].SetActive(true);
        }
    }

    public void UpgradeValue()
    {
        MainConttroller.Upgrade(UpgradeIndex);
    }

    public void ShowInfo()
    {
        ModalWindowsWithOutVariants.SetText(InfoTitleText,InfoText);
        ModalWindowsWithOutVariants.Show();
    }

    public void UpgradeWindow()
    {
        ModalWindowsWithVariants.SetText(UpgradeTitleText,UpgradeText);
        ModalWindowsWithVariants.Index = UpgradeIndex;
        ModalWindowsWithVariants.Show();
    }
}
