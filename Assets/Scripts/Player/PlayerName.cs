using Unity.Netcode;
using Unity.Collections;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> playerName { get; private set; } = new(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner) return;
        UsernameServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    [ServerRpc]
    private void UsernameServerRpc(ulong clientId)
    {
        FixedString32Bytes userNameData = new(SavedClientInformationManager.GetUserData(clientId).userName);
        UsernameClientRpc(userNameData);
    }

    [ClientRpc]
    private void UsernameClientRpc(FixedString32Bytes username)
    {
        if (!IsOwner) return;
        playerName.Value = username;
    }
}