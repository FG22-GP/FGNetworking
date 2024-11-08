using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] Image loadingBarImage;
    [SerializeField] Ammo ammo;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ammo.currentAmmo.OnValueChanged += UpdateUI;
    }

    private void UpdateUI(int previousValue, int newValue)
    {
        loadingBarImage.fillAmount = (float)newValue / ammo.MaxAmmo;
    }
}
