using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Ammo : NetworkBehaviour
{
    public NetworkVariable<int> currentAmmo = new NetworkVariable<int>();


    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        currentAmmo.Value = 10;
    }


    public void ChangeAmmoAmount(int ammo)
    {
        //damage = damage < 0 ? damage : - damage;
        //currentHealth.Value += damage;
    }

}
