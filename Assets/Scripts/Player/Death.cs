using Unity.Netcode;
using UnityEngine;
using System;

public class Death : NetworkBehaviour
{
    [SerializeField] Health health;

    public Action onDeathEvent;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        health.onDamageTakenEvent += OnDamageTaken;
    }

    private void OnDamageTaken()
    {
        if (!health.HasHealth())
        {
            onDeathEvent?.Invoke();
        }
    }
}