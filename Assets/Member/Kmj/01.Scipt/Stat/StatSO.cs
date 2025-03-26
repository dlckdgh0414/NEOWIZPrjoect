using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName = "StatSO", menuName = "SO/StatSO")]
public class StatSO : ScriptableObject, ICloneable
{
    public delegate void ValueChangeHandler(StatSO stat, float current, float previous);

    public event ValueChangeHandler OnValueChange;

    public string statName;
    public string description;

    [SerializeField] private Sprite icon;
    [SerializeField] private string displayName;
    [SerializeField] private float baseValue, minValue, maxValue;

    private Dictionary<object, float> _modifyDictionary = new Dictionary<object, float>();

    [field: SerializeField] public bool IsPercent { get; private set; }

    private float _modityValue = 0;

    public Sprite Icon => icon;

    public float MaxValue
    {
        get => maxValue;
        set => maxValue = value;
    }
    public float MinValue
    {
        get => minValue;
        set => minValue = value;
    }

    public float Value => Mathf.Clamp(baseValue + _modityValue, minValue, maxValue);
    public bool IsMax => Mathf.Approximately(Value, maxValue);
    public bool IsMin => Mathf.Approximately(Value, minValue);


    public float BaseValue
    {
        get => baseValue;

        set
        {
            float prevValue = Value;

            baseValue = Mathf.Clamp(value, minValue, maxValue);

            TryInvokeChnageEvent(Value, prevValue);
        }
    }

    public void AddModifier(object key, float value)
    {
        if (_modifyDictionary.ContainsKey(key)) return;

        float prevValue = Value;

        _modityValue += value;
        _modifyDictionary.Add(key, value);

        TryInvokeChnageEvent(Value, prevValue);
    }

    public void ReMoveModifier(object key)
    {
        if (_modifyDictionary.TryGetValue(key, out float value))
        {
            float prevValue = value;
            _modityValue -= value;
            _modifyDictionary.Remove(key);

            TryInvokeChnageEvent(value, prevValue);
        }
    }

    public void ClearAllModifier()
    {
        float prevValue = Value;

        _modifyDictionary.Clear();
        _modityValue = 0;
        TryInvokeChnageEvent(Value, prevValue);
    }

    private void TryInvokeChnageEvent(float value, float prevValue)
    {
        if (Mathf.Approximately(value, prevValue) == false)
        {
            OnValueChange?.Invoke(this, value, prevValue);
        }
    }

    public object Clone() => Instantiate(this);
}

