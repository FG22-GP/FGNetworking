using Unity.Netcode;
using Unity.Collections;

public class PlayerName : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> playerName = new(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        SetUserNameServerRpc(OwnerClientId);
    }

    [ServerRpc]
    private void SetUserNameServerRpc(ulong clientId)
    {
        SetUserNameClientRpc(SavedClientInformationManager.GetUserData(clientId).userName);
    }

    [ClientRpc]
    private void SetUserNameClientRpc(string newName)
    {
        if (!IsOwner) return;
        playerName.Value = newName;
    }
}