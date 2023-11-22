using System;
using TMPro;
using UnityEngine;

namespace Framework.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public TMP_Text textScore;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public float levelSpeed;
        public float maxLevelSpeed;
        public float timeScale;

        public int score;
        private float _score = 0f;

        private void Update()
        {
            _score += Time.deltaTime * levelSpeed;
            score = Mathf.FloorToInt(_score);

            textScore.text = score + "";
            
            if (levelSpeed < maxLevelSpeed)
                levelSpeed += Time.deltaTime * timeScale;
            if (levelSpeed > maxLevelSpeed)
                levelSpeed = maxLevelSpeed;
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("Score", score);
            
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
