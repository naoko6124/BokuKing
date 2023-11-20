using System.Collections.Generic;
using UnityEngine;

namespace Framework.Level
{
    public class LevelManager : MonoBehaviour
    {
        public LevelMovement currentLevelMovement;
        public GameObject currentLevel;
        public List<GameObject> levels;

        private void Update()
        {
            if (currentLevel.transform.position.y < currentLevelMovement.box.size.y / 2f)
            {
                GameObject nextLevel = levels[Random.Range(0, levels.Count)];
                Vector3 newPos = new Vector3(0f, currentLevel.transform.position.y, 0f);
                newPos.y += currentLevelMovement.box.size.y / 2f;
                currentLevel = Instantiate(nextLevel, new Vector3(10000f, 0f, 0f), Quaternion.identity);
                currentLevelMovement = currentLevel.GetComponent<LevelMovement>();
                newPos.y += currentLevelMovement.box.size.y / 2f;
                currentLevel.transform.position = newPos;
            }
        }
    }
}
