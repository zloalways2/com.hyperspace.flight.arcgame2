using Managers;
using UnityEngine;

namespace UI.Screens
{
    public abstract class Bnjwkenjkrnjwe : MonoBehaviour
    {
        protected CanvasView _canvas;
        protected BNjkewrkjhbvjhrt BNjkewrkjhbvjhrt;
        
        public void InjectData(CanvasView canvas, BNjkewrkjhbvjhrt bNjkewrkjhbvjhrt)
        {
            _canvas = canvas;
            BNjkewrkjhbvjhrt = bNjkewrkjhbvjhrt;
        }

        public virtual void BNjkwnjkrwejkbvhjk()
        {
            gameObject.SetActive(true);
        }

        public void KLASJruiwehuvbnteruigeyuidf()
        {
            gameObject.SetActive(false);
        }

        public virtual void OpenLevelListScreen()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<Vjekjqwheukhjkvbtnr>();
        }

        public virtual void OpenMenuScreen()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<CVNMklnerjknvjknrtk>();
        }
        
        public virtual void OpenSettingsScreen()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.ChangeScreen<VMklenwjkfnJKEd>();
        }

        public virtual void Back()
        {
            BNjkewrkjhbvjhrt.OnButtonClick();
            _canvas.OpenPreviousScreen();
        }
    }
}