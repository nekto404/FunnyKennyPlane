using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeElement : MonoBehaviour
{
    public GameObject[] Counter;
    public int[] UpgradePrice; 
    public ModalWindow ModalWindowsWithVariants;
    public ModalWindow ModalWindowsWithOutVariants;
    public menuConttroller MainConttroller;
    public String UpgradeText;
    public String UpgradeTitleText;
    public String InfoText;
    public String InfoTitleText;
    public int UpgradeIndex;
    public GameObject LookUpgrade;
    public NumberSpace PriceSpace;

    private int _value;

    public void SetValue(int newValue)
    {
        _value = newValue;
        for (int i = 0; i < _value; i++)
        {
            Counter[i].SetActive(true);
        }
        PriceSpace.Number = UpgradePrice[_value];
        PriceSpace.Show();
    }

    public void UpgradeValue()
    {
        MainConttroller.Upgrade(UpgradeIndex, UpgradePrice[_value]);
    }

    public void ShowInfo()
    {
        ModalWindowsWithOutVariants.SetText(InfoTitleText,InfoText);
        ModalWindowsWithOutVariants.Show();
    }

    public void UpgradeWindow()
    {
        ModalWindowsWithVariants.Price = UpgradePrice[_value];
        ModalWindowsWithVariants.SetText(UpgradeTitleText,UpgradeText);
        ModalWindowsWithVariants.Index = UpgradeIndex;
        ModalWindowsWithVariants.Show();
    }

    public void CheckPrice(int coins)
    {
        if (UpgradePrice[_value] > coins || UpgradePrice[_value]==-1)
        {
            LookUpgrade.SetActive(true);
        }
    }
}
