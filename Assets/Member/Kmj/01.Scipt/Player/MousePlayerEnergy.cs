using UnityEngine;

public class MousePlayerEnergy : MonoBehaviour
{
    [SerializeField] private EntityStat _stat;
    [SerializeField] private StatSO _energy;

    public float energy { get; private set; }

    public bool isEnergyNotzero { get; private set; } = true;

    private void Start()
    {
        energy = _stat.GetStat(_energy).Value;
    }

    public void UseEnergyTimeAtTime(int useEnergy)
    {
        energy -= useEnergy * (int)Time.deltaTime;
        print((int)Time.deltaTime);
    }

    public void UseEnergy(int useEnergy)
    {
        energy -= useEnergy;
    }

    private void Update()
    {
        EnergyIsFull();
    }

    private void EnergyIsFull()
    {
        if (energy < 0)
            isEnergyNotzero = false;
        else
            isEnergyNotzero = true;
    }



}
