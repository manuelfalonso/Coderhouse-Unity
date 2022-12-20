using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Each player has a damage total, represented by a percentage, which 
/// rises as the damage is taken and can reach maximum damage of 999%. 
/// As this percentage rises, the character is knocked progressively 
/// farther by attacks.
/// </summary>
public class TotalDamage : MonoBehaviour
{
    [SerializeField] private int _damageHitAdittion = 10;

    [SerializeField] private int _damageTotal = 0;
    public int DamageTotal { 
        get
        {
            return _damageTotal;
        } 
        private set
        {
            if (value <= MaxDamage)
            {
                _damageTotal = value;
                OnDamageChanged?.Invoke(value);
            }
        } 
    }

    public UnityEvent<int> OnDamageChanged = new UnityEvent<int>();

    public int MaxDamage { get; private set; }

    private Respawn _respawn;

    void Start()
    {
        MaxDamage = 999;
        _respawn = GetComponent<Respawn>();
        if (_respawn != null)
        {
            _respawn.OnLifeLost.AddListener(OnLifeLost);
        }
        DamageTotal = 0;
    }

    private void OnLifeLost()
    {
        _damageTotal = 0;
    }

    public void OnDeath()
    {
        _damageTotal = MaxDamage;
    }

    public int GetHit()
    {
        return DamageTotal += _damageHitAdittion;
    }
}
