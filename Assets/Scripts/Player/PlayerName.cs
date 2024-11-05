using Unity.Netcode;
using Unity.Collections;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> playerName = new(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        playerName.Value = UserDataWrapper.GetUserData().userName;
    }
}