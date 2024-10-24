using System;
using System.Collections.Generic;
using Content;
using Managers;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class CanvasView : MonoBehaviour
    {
        [FormerlySerializedAs("menuScreen")] [SerializeField] private CVNMklnerjknvjknrtk cvnMklnerjknvjknrtk;
        [FormerlySerializedAs("loadingScreen")] [SerializeField] private VNnrewkjrnjkhyt vNnrewkjrnjkhyt;
        [FormerlySerializedAs("gameScreen")] [SerializeField] private Bmkmfkweklnmjkvrtl bmkmfkweklnmjkvrtl;
        [FormerlySerializedAs("settingsScreen")] [SerializeField] private VMklenwjkfnJKEd vMklenwjkfnJkEd;
        [FormerlySerializedAs("levelListScreen")] [SerializeField] private Vjekjqwheukhjkvbtnr vjekjqwheukhjkvbtnr;
        [SerializeField] private ShopScreen shopScreen;
        [FormerlySerializedAs("winScreen")] [SerializeField] private VMklermklntbjkty vMklermklntbjkty;
        [FormerlySerializedAs("loseScreen")] [SerializeField] private BNJrnfjkwejkrq bnJrnfjkwejkrq;
        [SerializeField] private ExitScreen exitScreen;

        private Dictionary<Type, Bnjwkenjkrnjwe> _screens;
        private Bnjwkenjkrnjwe _previousScreen;
        private Bnjwkenjkrnjwe _currentScreen;
        private Context _context;

        private void Start()
        {
            _screens = new Dictionary<Type, Bnjwkenjkrnjwe>()
            {
                { typeof(CVNMklnerjknvjknrtk), cvnMklnerjknvjknrtk },
                { typeof(VNnrewkjrnjkhyt), vNnrewkjrnjkhyt },
                { typeof(Bmkmfkweklnmjkvrtl), bmkmfkweklnmjkvrtl },
                { typeof(VMklenwjkfnJKEd), vMklenwjkfnJkEd },
                { typeof(Vjekjqwheukhjkvbtnr), vjekjqwheukhjkvbtnr },
                { typeof(ShopScreen), shopScreen },
                { typeof(VMklermklntbjkty), vMklermklntbjkty },
                { typeof(BNJrnfjkwejkrq), bnJrnfjkwejkrq },
                { typeof(ExitScreen), exitScreen },
            };
        }

        public void Bootstrap(Context context)
        {
            _context = context;

            var levelSavesManager = context.Get<Bnjkwenrjkwe>();
            var soundManager = context.Get<BNjkewrkjhbvjhrt>();
            var shopData = context.Get<Bnjkgnrjkweqw>();

            foreach (var pair in _screens)
            {
                pair.Value.InjectData(this, soundManager);
            }

            vjekjqwheukhjkvbtnr.Bootstrap(levelSavesManager);
            cvnMklnerjknvjknrtk.Bootstrap(levelSavesManager);
            bmkmfkweklnmjkvrtl.Bootstrap(levelSavesManager, shopData);
            vMklenwjkfnJkEd.Bootstrap();
            shopScreen.Bootstrap(levelSavesManager, shopData);
        }

        public void Load()
        {
            ChangeScreen<VNnrewkjrnjkhyt>();
            vNnrewkjrnjkhyt.Load();
        }

        public void ChangeScreen<TScreen>() where TScreen : Bnjwkenjkrnjwe
        {
            _previousScreen = _currentScreen;
            _previousScreen?.KLASJruiwehuvbnteruigeyuidf();
            _currentScreen = _screens[typeof(TScreen)];
            _currentScreen.BNjkwnjkrwejkbvhjk();
        }

        public void ChangeScreen<TScreen, TPayload>(TPayload payload) where TScreen : Bnjwkenjkrnjwe
        {
            ((VMSeklnjkVJKRvnjkrt<TPayload>)_screens[typeof(TScreen)]).SetPayload(payload);
            ChangeScreen<TScreen>();
        }

        public void OpenPreviousScreen()
        {
            if (_previousScreen is null)
                return;

            _currentScreen.KLASJruiwehuvbnteruigeyuidf();
            _previousScreen.BNjkwnjkrwejkbvhjk();

            (_previousScreen, _currentScreen) = (_currentScreen, _previousScreen);
        }
    }
}