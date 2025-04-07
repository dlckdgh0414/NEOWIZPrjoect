using System.Collections;
using UnityEngine;

public class MousePlayerEnergy : MonoBehaviour
{
    [SerializeField] private EntityStat _stat;
    [SerializeField] private StatSO _energy;

    public float energy { get; private set; }

    public bool isEnergyNotzero { get; private set; } = true;

    private Coroutine skillCoroutine;


    private void Start()
    {
        energy = _stat.GetStat(_energy).Value;
    }
    public void UseEnergy(int useEnergy)
    {
        energy -= useEnergy;
    }

    private void Update()
    {
        isEnergyNotzero = energy > 0;

        if(energy <= 0)
        {
            energy = 0;
        }
    }

    public void StartSkill(int useEnergy)
    {
        if (skillCoroutine == null)
        {
            skillCoroutine = StartCoroutine(UseSkill(useEnergy));
        }
    }

    // 스킬 취소
    public void CancelSkill()
    {
        if (skillCoroutine != null)
        {
            StopCoroutine(skillCoroutine);
            skillCoroutine = null;
        }
    }

    private IEnumerator UseSkill(int useEnergy)
    {
        while (true)
        {
            if (energy >= useEnergy)
            {
                energy -= useEnergy;
                Debug.Log($"Skill active. Energy left: {energy}");
            }
            else
            {
                Debug.Log("Not enough energy!");
                CancelSkill();
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
