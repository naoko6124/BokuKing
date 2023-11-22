using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scenes.GameOver.Scripts
{
    public class Restart : MonoBehaviour
    {
        public void BackToGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
