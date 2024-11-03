using Unity.Netcode;
using UnityEngine;
using System;

public class Death : NetworkBehaviour
{
    [SerializeField] Health health;
    //[SerializeField] Ammo ammo;

    public override void OnNetworkSpawn()
    {
        health.onDamageTakenEvent += OnDamageTaken;
    }

    private void OnDamageTaken()
    {
        if (!health.HasHealth())
        {
            health.Reset();
            //ammo.Reset();
        }
    }
}