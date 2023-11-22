using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scenes.MainMenu.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public void NewGame()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
