using Unity.Netcode;
using Unity.Collections;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> playerName = new(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    void Start()
    {
        if (!IsOwner) return;
        UsernameServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    [ServerRpc]
    private void UsernameServerRpc(ulong clientId)
    {
        UsernameClientRpc(SavedClientInformationManager.GetUserData(clientId).userName);
    }

    [ClientRpc]
    private void UsernameClientRpc(string username)
    {
        Debug.LogWarning(username);
        if (!IsOwner) return;
        playerName.Value = username;
    }
}