using UnityEngine;

namespace Managers
{
    public class BNjkewrkjhbvjhrt : MonoBehaviour
    {
        private const string VNjkewnjkr = "Bnjkwenjkrwek";
        private const string BVNJhbwjker = "VNkrjenjkrtg";

        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource buttonClick;
        [SerializeField] private AudioSource winSound;
        [SerializeField] private AudioSource loseSound;
        [SerializeField] private AudioSource coinCollect;
        
        public bool SoundMuted { get; set; }

        public bool MusicMuted
        {
            get => backgroundMusic.mute;
            set => backgroundMusic.mute = value;
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(VNjkewnjkr))
                PlayerPrefs.SetInt(VNjkewnjkr, MusicMuted ? 1 : 0);
            
            if (!PlayerPrefs.HasKey(BVNJhbwjker))
                PlayerPrefs.SetInt(BVNJhbwjker, SoundMuted ? 1 : 0);

            MusicMuted = PlayerPrefs.GetInt(VNjkewnjkr) == 1;
            SoundMuted = PlayerPrefs.GetInt(BVNJhbwjker) == 1;
        }

        public void OnButtonClick()
        {
            if (SoundMuted)
                return;
            
            buttonClick.Play();
        }

        public void OnCoinCollect()
        {
            if (SoundMuted)
                return;

            coinCollect.Play();
        }

        public void OnWin()
        {
            if (SoundMuted)
                return;

            winSound.Play();
        }
        
        public void OnLose()
        {
            if (SoundMuted)
                return;

            loseSound.Play();
        }

        public void StartBackgroundMelody()
        {
            backgroundMusic.Play();
        }
    }
}