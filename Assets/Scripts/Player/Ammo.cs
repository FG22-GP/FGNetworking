using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Ammo : NetworkBehaviour
{
    public NetworkVariable<int> currentAmmo = new NetworkVariable<int>();

    public int MaxAmmo { get; private set; } = 10;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        Reset();
    }

    public void AddAmmo(int ammo)
    {
        ammo = ammo > 0 ? ammo : -ammo;
        ChangeAmmoAmount(ammo);
    }

    public void RemoveAmmo(int ammo)
    {
        ammo = ammo < 0 ? ammo : -ammo;
        ChangeAmmoAmount(ammo);
    }

    private void ChangeAmmoAmount(int amount)
    {
        currentAmmo.Value = Mathf.Clamp(currentAmmo.Value + amount, 0, MaxAmmo);
    }

    public void Reset()
    {
        currentAmmo.Value = MaxAmmo;
    }

    public bool HasAmmo()
    {
        return currentAmmo.Value > 0;
    }

}
