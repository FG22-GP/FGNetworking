using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class AmmoMine : NetworkBehaviour
{

    [SerializeField] GameObject minePrefab;
    public int ammoAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsServer)
        {
            Ammo ammo = other.GetComponent<Ammo>();
            if (!ammo) return;
            //health.TakeDamage(25);

            int xPosition = Random.Range(-4, 4);
            int yPosition = Random.Range(-2, 2);


            GameObject newMine = Instantiate(minePrefab, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            NetworkObject no = newMine.GetComponent<NetworkObject>();
            no.Spawn();



            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
}
