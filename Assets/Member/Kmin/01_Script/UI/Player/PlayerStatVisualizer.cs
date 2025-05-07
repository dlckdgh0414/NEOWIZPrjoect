using System;
using TMPro;
using UnityEngine;

public class PlayerStatVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private StatSO attackStatSO;
    [SerializeField] private StatSO healthStatSO;

    private void Update()
    {
        attackText.text = $"공격력 : {attackStatSO.Value}";
        healthText.text = $"체력 : {healthStatSO.Value}";
    }
}
