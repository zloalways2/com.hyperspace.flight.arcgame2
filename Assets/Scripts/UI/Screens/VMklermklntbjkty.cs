using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VMklermklntbjkty : VMSeklnjkVJKRvnjkrt<GamePayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text levelText;

        public override void BNjkwnjkrwejkbvhjk()
        {
            levelText.text = $"LEVEL {_payload.SelectedLevel + 1}";
            scoreText.text = $"SCORE: {_payload.Score}";
            
            base.BNjkwnjkrwejkbvhjk();
        }

        public void Next()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            if (_payload.SelectedLevel >= 28)
            {
                _canvas.ChangeScreen<CVNMklnerjknvjknrtk>();
                return;
            }
            
            _canvas.ChangeScreen<Bmkmfkweklnmjkvrtl, GamePayload>(new GamePayload()
            {
                SelectedLevel = _payload.SelectedLevel + 1
            });
        }
    }
}