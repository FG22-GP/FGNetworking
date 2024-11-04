using Unity.Netcode;
using UnityEngine;

public class Lives : NetworkBehaviour
{
    [SerializeField] Death death;
    [SerializeField] Health health;
    [SerializeField] Ammo ammo;

    NetworkVariable<int> currentLives = new();
    public int MaxLives { get; private set; } = 3;

    public override void OnNetworkSpawn()
    {
        death.onDeathEvent += OnDeath;
        if (!IsOwner) return;
        currentLives.Value = MaxLives;
    }

    private void OnDeath()
    {
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