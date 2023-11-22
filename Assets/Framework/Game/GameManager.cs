using System;
using UnityEngine;

namespace Framework.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public float levelSpeed;

        public int score;
        private float fScore = 0f;

        private void Update()
        {
            fScore += Time.deltaTime * levelSpeed;
            score = Mathf.FloorToInt(fScore);
        }
    }
}