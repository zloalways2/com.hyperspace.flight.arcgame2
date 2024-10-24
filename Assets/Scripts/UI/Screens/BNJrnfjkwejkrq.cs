using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class BNJrnfjkwejkrq : VMSeklnjkVJKRvnjkrt<GamePayload>
    {
        [SerializeField] private Text levelText;
        
        public override void BNjkwnjkrwejkbvhjk()
        {
            levelText.text = $"LEVEL {_payload.SelectedLevel + 1}";
            
            base.BNjkwnjkrwejkbvhjk();
        }
        
        public void TryAgain()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();

            _canvas.ChangeScreen<Bmkmfkweklnmjkvrtl, GamePayload>(_payload);
        }
    }
}