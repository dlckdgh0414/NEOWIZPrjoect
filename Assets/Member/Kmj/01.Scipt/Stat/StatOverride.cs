using UnityEngine;

public class StatOverride : MonoBehaviour
{
    [SerializeField] private StatSO stat;
    [SerializeField] private bool IsUseOverride;
    [SerializeField] private float overrideValue;

    public StatOverride(StatSO stat) => this.stat = stat;

    public StatSO CreateSet()
    {
        StatSO newStat = stat.Clone() as StatSO;

        if (IsUseOverride)
            newStat.BaseValue = overrideValue;

        return newStat;
    }
}
