using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scenes.GameOver.Scripts
{
    public class Restart : MonoBehaviour
    {
        public TMP_Text textScore;
        public TMP_Text textHighScore;

        private void Start()
        {
            textScore.text = "" + PlayerPrefs.GetInt("Score", 0);
            textHighScore.text = "" + PlayerPrefs.GetInt("HighScore", 0);
        }

        public void BackToGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
