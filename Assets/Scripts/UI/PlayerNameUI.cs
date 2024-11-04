using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Collections;

public class PlayerNameUI : NetworkBehaviour
{
    [SerializeField] Text playerNameUi;
    NetworkVariable<FixedString32Bytes> playerName = new();

    public override void OnNetworkSpawn()
    {
        playerName.OnValueChanged += UpdateUI;
        if (!IsOwner) return;
        playerName.Value = UserDataWrapper.GetUserData().userName;
    }

    private void UpdateUI(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerNameUi.text = newName.ToString();
    }
}