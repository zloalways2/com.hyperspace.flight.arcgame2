using System.Collections;
using System.Linq;
using Content;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class ShopScreen : Bnjwkenjkrnjwe
    {
        [SerializeField] private Text balanceText;
        [SerializeField] private Text buttonText;
        [SerializeField] private Text[] shipCosts;
        [SerializeField] private float animationDuration = 1;
        [SerializeField] private Color wrongColor = new Color(
            201 / 255f, 
            22 / 255f, 
            43 / 255f
        );
        
        private Bnjkwenrjkwe _bnjkwenrjkwe;
        private Bnjkgnrjkweqw _bnjkgnrjkweqw;
        private Color _defaultColor;
        private int _selectedKey = 0;
        
        public void Bootstrap(Bnjkwenrjkwe bnjkwenrjkwe, Bnjkgnrjkweqw bnjkgnrjkweqw)
        {
            _bnjkwenrjkwe = bnjkwenrjkwe;
            _bnjkgnrjkweqw = bnjkgnrjkweqw;
        }

        private void Awake()
        {
            _defaultColor = balanceText.color;
        }

        public override void BNjkwnjkrwejkbvhjk()
        {
            base.BNjkwnjkrwejkbvhjk();
            
            balanceText.color = _defaultColor;
            UpdateText();
        }

        public void SelectShip(int key)
        {
            _selectedKey = key;

            buttonText.text = _bnjkwenrjkwe.BVNJKrnjkwer.Contains(key) ? "SELECT" : "BUY";
        }

        public void OnButtonClick()
        {
            if (buttonText.text == "SELECT")
            {
                _bnjkwenrjkwe.BNjkenwkjrkjq = _selectedKey;
            }
            else
            {
                if (_bnjkgnrjkweqw.Vbnjekwnrkjw[_selectedKey] > _bnjkwenrjkwe.VBNjrnejkrt)
                {
                    StartCoroutine(WrongBalance());
                    return;
                }

                _bnjkwenrjkwe.VBNjrnejkrt -= _bnjkgnrjkweqw.Vbnjekwnrkjw[_selectedKey];
                _bnjkwenrjkwe.BVNJKrnjkwer = _bnjkwenrjkwe.BVNJKrnjkwer
                    .Concat(new[] { _selectedKey })
                    .ToArray();
                    
                _bnjkwenrjkwe.BNjkenwkjrkjq = _selectedKey;
            }
            
            UpdateText();
        }

        private void UpdateText()
        {
            var boughtShips = _bnjkwenrjkwe.BVNJKrnjkwer;
            
            for (int i = 0; i < shipCosts.Length; ++i)
            {
                if (i == _bnjkwenrjkwe.BNjkenwkjrkjq)
                {
                    shipCosts[i].text = "SELECTED";
                    continue;
                }
                
                if (boughtShips.Contains(i))
                {
                    shipCosts[i].text = "";
                    continue;
                }
                
                shipCosts[i].text = $"{_bnjkgnrjkweqw.Vbnjekwnrkjw[i]}";
            }
            
            balanceText.text = $"BALANCE\n{_bnjkwenrjkwe.VBNjrnejkrt}";
        }

        private IEnumerator WrongBalance()
        {
            float passedTime = 0;

            while (passedTime < animationDuration * 3)
            {
                passedTime += Time.deltaTime;

                balanceText.color = (int)(passedTime / animationDuration) % 2 == 0
                    ? wrongColor
                    : _defaultColor;

                yield return null;
            }

            balanceText.color = _defaultColor;
        }
    }
}