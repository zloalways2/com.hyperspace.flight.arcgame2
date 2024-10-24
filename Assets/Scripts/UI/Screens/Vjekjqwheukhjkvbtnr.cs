using Managers;
using UnityEngine;

namespace UI.Screens
{
    public class Vjekjqwheukhjkvbtnr : Bnjwkenjkrnjwe
    {
        [SerializeField] private LevelButton[] levelButtons;
        
        private Bnjkwenrjkwe _bnjkwenrjkwe;

        private void Start()
        {
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                var t = i;
                levelButtons[i].Button.onClick.AddListener(() => ASHuhiwfueuivbt(t));
            }
        }

        public void Bootstrap(
            Bnjkwenrjkwe bnjkwenrjkwe
        )
        {
            _bnjkwenrjkwe = bnjkwenrjkwe;
            WaiHJUIVHUIRTBIVRT();
        }
        
        public void ASHuhiwfueuivbt(int levelIndex)
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<Bmkmfkweklnmjkvrtl, GamePayload>(new GamePayload { SelectedLevel = levelIndex });
        }
        
        public override void BNjkwnjkrwejkbvhjk()
        {
            WaiHJUIVHUIRTBIVRT();
            
            base.BNjkwnjkrwejkbvhjk();
        }
        
        private void WaiHJUIVHUIRTBIVRT()
        {
            var results = _bnjkwenrjkwe.QGwiqgeivrt;
            
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                levelButtons[i].Button.interactable = i <= _bnjkwenrjkwe.PassedLevels;
                levelButtons[i].SetResult(results[i]);
            }
        }
    }
}