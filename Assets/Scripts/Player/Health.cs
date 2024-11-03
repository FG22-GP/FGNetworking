using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using System;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    public Action onDamageTakenEvent;

    private const int maxHealth = 100;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        Reset();
    }

    public void TakeDamage(int damage)
    {
        damage = damage < 0 ? damage : -damage;
        ChangeHealth(damage);

        onDamageTakenEvent?.Invoke();
    }

    public void RegainHealth(int health)
    {
        health = health > 0 ? health : -health;
        ChangeHealth(health);
    }

    private void ChangeHealth(int amount)
    {
        currentHealth.Value += amount;
        Mathf.Clamp(currentHealth.Value, 0, maxHealth);
    }

    public void Reset()
    {
        currentHealth.Value = 100;
    }

    public bool HasHealth()
    {
        return currentHealth.Value > 0;
    }
}
