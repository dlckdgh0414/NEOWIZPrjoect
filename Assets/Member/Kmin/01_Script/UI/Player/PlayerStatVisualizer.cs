using System;
using TMPro;
using UnityEngine;

public class PlayerStatVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [SerializeField] private EntityHealth health;
    [SerializeField] private PlayerAttackCompo attack;

    private void Awake()
    {
        /*_atkValue = statCompo.GetStat(attackStatSO).Value;
        healthStatSO = statCompo.GetStat(healthStatSO).Value;*/
    }

    private void Update()
    {
        attackText.text = $"공격력 : {attack.atkDamage}";
        healthText.text = $"체력 : {health.currentHealth}";
    }
}
