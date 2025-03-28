using System.Linq;
using UnityEngine;

public class EntityStat : MonoBehaviour, IEntityComponet
{

    [SerializeField] private StatOverride[] statOverride;
    private StatSO[] _stat;

    public Entity owner { get; private set; }
    public void Initialize(Entity entity)
    {
        owner = entity;

        _stat = statOverride.Select(stat => stat.CreateSet()).ToArray();
    }

    public StatSO GetStat(StatSO targetState)
    {
        return _stat.FirstOrDefault(stat => stat.statName == targetState.statName);
    }

    public bool TryGetStat(StatSO statSO, out StatSO outstat)
    {
        outstat = _stat.FirstOrDefault(stat => stat.statName == statSO.statName);

        return outstat;
    }

    public void SetBaseValue(StatSO statSO, float value) => GetStat(statSO).BaseValue = value;

    public float GetBaseValue(StatSO statSO) => GetStat(statSO).BaseValue;


    public void IncreaseBaseValue(StatSO stat, float value) => GetStat(stat).BaseValue += value;

    public void AddModifier(StatSO stat, object key, float value) => GetStat(stat).AddModifier(key, value);

    public void RemoveModifier(StatSO stat, object key) => GetStat(stat).ReMoveModifier(key);

    public void CleanAllModifier()
    {
        foreach (StatSO stat in _stat)
        {
            stat.ClearAllModifier();
        }
    }
}
