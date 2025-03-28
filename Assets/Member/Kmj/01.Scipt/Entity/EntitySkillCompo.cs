using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitySkillCompo : MonoBehaviour, IEntityComponet
{
    private Entity _entity;

    public List<SkillSO> skills;

    public Dictionary<string, SkillSO> skillList = new Dictionary<string, SkillSO>();
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    private void Awake()
    {
        AddSkillInDictionary();
        skillList.ToList().ForEach(skill => skill.Value.currentcoolTime = 0);  
    }


    private void Update()
    {
        foreach (var skill in skillList)
        {
            if (skill.Value.currentcoolTime >= skill.Value.skillCoolTime)
                return;
            else
            {
                skill.Value.currentcoolTime += 1 * Time.deltaTime; 
            }
        }


    }
    private void AddSkillInDictionary()
    {
        skills.ForEach(skill => skillList.Add(skill.skillName, skill));
    }

    public bool CanUseSkill(string name)
    {
        if (skillList.GetValueOrDefault(name).currentcoolTime >=
           skillList.GetValueOrDefault(name).skillCoolTime)
            return true;
        else
            return false;
    }



}
