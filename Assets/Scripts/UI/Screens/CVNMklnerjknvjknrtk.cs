using Managers;
using UnityEngine;

namespace UI.Screens
{
    public class CVNMklnerjknvjknrtk : Bnjwkenjkrnjwe
    {
        private Bnjkwenrjkwe _bnjkwenrjkwe;

        public void Bootstrap(
            Bnjkwenrjkwe bnjkwenrjkwe
        )
        {
            _bnjkwenrjkwe = bnjkwenrjkwe;
        }

        public void StartGame()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<Bmkmfkweklnmjkvrtl, GamePayload>(
                new GamePayload() { SelectedLevel = _bnjkwenrjkwe.BNkgjlnrjkrnjkqwe }
            );
            _canvas.ChangeScreen<Bmkmfkweklnmjkvrtl, GamePayload>(new GamePayload { SelectedLevel = _bnjkwenrjkwe.BNkgjlnrjkrnjkqwe });
        }

        public void OpenShop()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<ShopScreen>();
        }

        public void OpenExitScreen()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<ExitScreen>();
        }
        
        public void Exit()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            Application.Quit();
        }
    }
}