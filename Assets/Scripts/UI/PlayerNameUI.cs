using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField] Text playerNameUi;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        UpdateUI(UserDataWrapper.GetUserData().userName);
    }

    private void UpdateUI(string name)
    {
        playerNameUi.text = name;
    }
}