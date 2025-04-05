using System;
using UnityEngine;

    //모든 스크립트보다 빨리 실행돼.
    [DefaultExecutionOrder(-20)]
    public class SceneTransitionManager : MonoBehaviour
    {
        [SerializeField] private EntityFinderSO playerFinder;

        private void Awake()
        {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            Debug.Assert(player != null, "player does not exist in this scene");

            foreach (var p in player)
            {
                playerFinder.SetPlayer(p);
            }
        }
    }