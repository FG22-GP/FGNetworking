using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using System;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    public Action onDamageTakenEvent;

    public int MaxHealth { get; private set; } = 100;

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
        currentHealth.Value = Mathf.Clamp(currentHealth.Value + amount, 0, MaxHealth);
    }

    public void Reset()
    {
        currentHealth.Value = MaxHealth;
    }

    public bool HasHealth()
    {
        return currentHealth.Value > 0;
    }
}