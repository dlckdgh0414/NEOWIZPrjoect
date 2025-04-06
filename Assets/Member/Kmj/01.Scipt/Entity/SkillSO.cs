using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Skill/So", fileName ="SKills")]

public class SkillSO : ScriptableObject
{
    public string skillName;
    public Image skillUIImage;
    public float skillDamage;
    public float skillCoolTime;
    public float currentcoolTime;

    private void OnValidate()
    {
        if (currentcoolTime >= skillCoolTime)
            currentcoolTime = skillCoolTime;
    }
}
