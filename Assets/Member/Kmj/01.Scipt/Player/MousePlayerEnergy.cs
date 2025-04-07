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
        energy -= useEnergy * Time.deltaTime;
        print((int)Time.deltaTime);
    }

    public void UseEnergy(int useEnergy)
    {
        energy -= useEnergy;
    }

    private void Update()
    {
        isEnergyNotzero = energy > 0;
    }



}
