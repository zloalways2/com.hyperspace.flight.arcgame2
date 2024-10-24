using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VMklenwjkfnJKEd : Bnjwkenjkrnjwe
    {
        [FormerlySerializedAs("soundToggle")] [SerializeField] private Toggle VNjkenwkj4rg;
        [FormerlySerializedAs("musicToggle")] [SerializeField] private Toggle VLOKeiowjeuiovnt;
        
        public void Bootstrap()
        {
            VMKLemjklrhjknVKJHre();
        }

        public override void BNjkwnjkrwejkbvhjk()
        {
            base.BNjkwnjkrwejkbvhjk();

            VMKLemjklrhjknVKJHre();
        }
        
        public void ToggleMusic()
        {
            BNjkewrkjhbvjhrt.MusicMuted = !BNjkewrkjhbvjhrt.MusicMuted;
            BNjkewrkjhbvjhrt.OnButtonClick();
            VMKLemjklrhjknVKJHre();
        }

        public void ToggleSound()
        {
            BNjkewrkjhbvjhrt.SoundMuted = !BNjkewrkjhbvjhrt.SoundMuted;
            BNjkewrkjhbvjhrt.OnButtonClick();
            VMKLemjklrhjknVKJHre();
        }

        private void VMKLemjklrhjknVKJHre()
        {
            VNjkenwkj4rg.graphic.gameObject.SetActive(!BNjkewrkjhbvjhrt.SoundMuted);
            VLOKeiowjeuiovnt.graphic.gameObject.SetActive(!BNjkewrkjhbvjhrt.MusicMuted);
        }
    }
}