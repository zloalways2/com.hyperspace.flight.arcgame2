using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VNnrewkjrnjkhyt : Bnjwkenjkrnjwe
    {
        [SerializeField] private float loadingDuration = 1f;
        
        public void Load()
        {
            StartCoroutine(LoadingCoroutine());
        }

        private IEnumerator LoadingCoroutine()
        {
            var loadingProgress = 0f;
            while (loadingProgress < loadingDuration)
            {
                loadingProgress += Time.deltaTime;
                
                yield return null;
            }
            
            BNjkewrkjhbvjhrt.StartBackgroundMelody();
            _canvas.ChangeScreen<CVNMklnerjknvjknrtk>();
        }
    }
}