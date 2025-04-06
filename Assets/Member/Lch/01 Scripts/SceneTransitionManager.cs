using System;
using UnityEngine;

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