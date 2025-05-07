using System.Collections;
using Code.Entities;
using UnityEngine;

public class MousePlayerEnergy : MonoBehaviour
{
    [SerializeField] private EntityStat _stat;
    [SerializeField] private StatSO _energy;

    public float energy { get;  set; }

    public bool isEnergyNotzero { get; private set; } = true;

    private Coroutine skillCoroutine;

    private Coroutine AutoFillCoroutine;
    private Coroutine AutoMagFillCoroutine;

    [SerializeField] private float Recover = 10;
    [SerializeField] private float Mag = 0;
    [SerializeField] private float MaxMag = 10;
    [SerializeField] private float RecoverMaxCount = 2f;
    public bool isUseEnergy { get;  set; }

    private void Start()
    {
        energy = _stat.GetStat(_energy).Value;
        StartFill();

        StartFillMag();
    }
    public void UseEnergy(int useEnergy)
    {
       // energy -= useEnergy;
    }


    private void Update()
    {
        isEnergyNotzero = energy >= 0;

        if (energy <= 0)
        {
            energy = 0;
        }

        if (Mag >= MaxMag)
        {
            Mag = MaxMag;
        }

    }

    public void StartSkill(float useEnergy)
    {
        if (skillCoroutine == null)
        {
            Mag = 0;
            skillCoroutine = StartCoroutine(UseSkill(useEnergy));
        }
    }


    public void CancelSkill()
    {
        if (skillCoroutine != null)
        {
            StopCoroutine(skillCoroutine);
            skillCoroutine = null;
        }
    }


    public void StartFill()
    {
        if (AutoFillCoroutine == null)
        {
            isUseEnergy = false;
            AutoFillCoroutine = StartCoroutine(AutoHealEnergy());
        }
    }

    public void StartFillMag()
    {
        if (AutoMagFillCoroutine == null)
        {
            isUseEnergy = false;
            Mag = 0;
            AutoMagFillCoroutine = StartCoroutine(AutoChargeMag());
        }
    }

    public void StopHeal()
    {
        if (AutoFillCoroutine != null)
        {
            isUseEnergy = true;
            StopCoroutine(AutoFillCoroutine);
            AutoFillCoroutine = null;
        }
    }

    public void StopMag()
    {
        if (AutoMagFillCoroutine != null)
        {
            isUseEnergy = true;
            StopCoroutine(AutoMagFillCoroutine);
            AutoMagFillCoroutine = null;
        }
    }

    private IEnumerator UseSkill(float useEnergy)
    {
        while (true)
        {
            if (energy >= useEnergy)
            {
                energy -= useEnergy + 3.8f;
            }
            else
            {
                CancelSkill();
                yield break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator AutoHealEnergy()
    {
        yield return new WaitForSeconds(1f);
        while(energy <= 200 && !isUseEnergy)
        {
            energy += Recover * Mag / 50;
            yield return new WaitForSeconds(0.01f);
        
        }
    }

    private IEnumerator AutoChargeMag()
    {
        yield return new WaitForSeconds(1f);
        while (!isUseEnergy && Mag <= MaxMag)
        {
            Mag += RecoverMaxCount / MaxMag / 5;
            yield return new WaitForSeconds(0.01f);  
        }
    }
}
