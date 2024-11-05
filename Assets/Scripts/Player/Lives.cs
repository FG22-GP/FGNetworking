using Unity.Netcode;
using UnityEngine;

public class Lives : NetworkBehaviour
{
    [SerializeField] Death death;
    [SerializeField] Health health;
    [SerializeField] Ammo ammo;

    NetworkVariable<int> currentLives = new(3, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    public int MaxLives { get; private set; } = 3;

    public override void OnNetworkSpawn()
    {
        death.onDeathEvent += OnDeath;
        if (!IsServer) return;
        currentLives.Value = MaxLives;
    }

    private void OnDeath()
    {
        if (!IsServer) return;
        currentLives.Value--;
        if (currentLives.Value > 0)
        {
            Respawn();
        }
        else
        {
            Despawn();
        }
    }

    private void Respawn()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        health.Reset();
        ammo.Reset();
    }

    private void Despawn()
    {
        GetComponent<NetworkObject>().Despawn();
    }
}