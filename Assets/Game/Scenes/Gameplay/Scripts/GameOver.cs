using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scenes.Gameplay.Scripts
{
    public class GameOver : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
