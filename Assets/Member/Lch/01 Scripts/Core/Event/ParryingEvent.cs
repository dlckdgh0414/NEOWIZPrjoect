using UnityEngine;

public class ParryingEvent
{
    public static ParryingDamage ParryingDamage = new ParryingDamage();
}


public class ParryingDamage
{
    public float damge;
    public bool IsParryingAttackEnd;
}
