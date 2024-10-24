using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image[] levelResults;
        [SerializeField] private Sprite noResultSprite;
        [SerializeField] private Sprite resultStarSprite;

        public Button Button => button;

        public void SetResult(int result)
        {
            for (int i = 0; i < levelResults.Length; ++i)
            {
                levelResults[i].sprite = i < result
                    ? resultStarSprite
                    : noResultSprite;
            }
        }
    }
}