using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField] Text playerNameUi;
    [SerializeField] PlayerName playerName;

    void Awake()
    {
        playerName.playerName.OnValueChanged += UpdateUI;
    }

    private void UpdateUI(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerNameUi.text = newName.ToString();
    }
}