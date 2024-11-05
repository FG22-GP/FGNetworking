using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField] Text playerNameUi;
    [SerializeField] PlayerName playerName;

    void OnEnable()
    {
        playerName.playerName.OnValueChanged += UpdateUI;
    }

    void OnDisable()
    {
        playerName.playerName.OnValueChanged -= UpdateUI;
    }

    private void UpdateUI(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerNameUi.text = newName.ToString();
    }
}