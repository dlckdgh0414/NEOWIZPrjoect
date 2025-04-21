using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestSkillTree : MonoBehaviour
{
    [SerializeField] private List<SkillTreeNode> fruitsList;
    [SerializeField] private SkillTreeSO skillTreeSO;
    [SerializeField] private GameEventChannelSO eventChannelSO;
    
    private SkillTreeEvent _skillTreeEvent = SkillTreeEventChannel.SkillTreeEvent;

    private void Awake()
    {
        fruitsList.ForEach(f => f.Initialize());

        foreach (SkillTreeNode f in fruitsList)
        {
            f.NodeButton.onClick.AddListener(() => SelectFruits(f.GetNodeSO()));
        }
        
        eventChannelSO.AddListener<SkillTreePurchaseEvent>(HandleFruitsPurchase);
    }

    private void HandleFruitsPurchase(SkillTreePurchaseEvent skillTreeEvent)
    {
        StartCoroutine(TestConnect(skillTreeEvent.SkillTreeNode));
    }

    public void SelectFruits(NodeSO selectedNode)
    {
        _skillTreeEvent.NodeSo = selectedNode;
        eventChannelSO.RaiseEvent(_skillTreeEvent);
    }

    private IEnumerator TestConnect(SkillTreeNode f)
    {
        Debug.Log(f);
        f.transform.SetSiblingIndex(f.transform.parent.childCount - 2);
        DOTween.Kill(f);
        for (int i = 0; i < 3; i++)
        {
            DOTween.To(() => 0, amount => f.FillBranch[i].fillAmount = amount, 1f, 0.2f)
                .SetEase(Ease.OutQuad);
            yield return new WaitUntil(() => f.FillBranch[i].fillAmount == 1);
        }
    }
}
