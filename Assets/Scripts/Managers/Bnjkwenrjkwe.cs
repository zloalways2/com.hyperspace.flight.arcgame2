using System;
using System.Linq;
using Content;
using Entities;
using UnityEngine;

namespace Managers
{
    public class Bnjkwenrjkwe
    {
        private const string FJKldjlkrwe = "PassedLevels";
        private const string Vnbjhrebwhbkqw = "ScoreKey";
        private const string WIoqwehonvtjk = "BoughtShips";
        private const string VNvjkrenjkq = "SelectedShip";
        private const string VOPopqjwiojruinrtji = "LevelResult";
        
        private readonly Nnvjkernkjq _nnvjkernkjq;

        public int PassedLevels => PlayerPrefs.GetInt(FJKldjlkrwe);
        public int LevelsCount => _nnvjkernkjq.VNnjkwenkrq.Length;

        public int VBNjrnejkrt
        {
            get => PlayerPrefs.GetInt(Vnbjhrebwhbkqw);
            set => PlayerPrefs.SetInt(Vnbjhrebwhbkqw, value);
        }

        public int[] BVNJKrnjkwer
        {
            get => PlayerPrefs.GetString(WIoqwehonvtjk)
                .Split(',')
                .Select(c => Convert.ToInt32(c))
                .ToArray();
            set => PlayerPrefs.SetString(WIoqwehonvtjk, String.Join(",", value));
        }

        public int BNjkenwkjrkjq
        {
            get => PlayerPrefs.GetInt(VNvjkrenjkq);
            set => PlayerPrefs.SetInt(VNvjkrenjkq, value);
        }

        public int[] QGwiqgeivrt
        {
            get => PlayerPrefs.GetString(VOPopqjwiojruinrtji)
                .Split(',')
                .Select(c => Convert.ToInt32(c))
                .ToArray();
            set => PlayerPrefs.SetString(VOPopqjwiojruinrtji, String.Join(",", value));
        }

        public int BNkgjlnrjkrnjkqwe => PlayerPrefs.GetInt(FJKldjlkrwe) < _nnvjkernkjq.VNnjkwenkrq.Length
            ? PlayerPrefs.GetInt(FJKldjlkrwe)
            : _nnvjkernkjq.VNnjkwenkrq.Length - 1;
            
        
        public Bnjkwenrjkwe(Nnvjkernkjq nnvjkernkjq)
        {
            _nnvjkernkjq = nnvjkernkjq;

            if (!PlayerPrefs.HasKey(FJKldjlkrwe))
            {
                PlayerPrefs.SetInt(FJKldjlkrwe, 0);
            }

            if (!PlayerPrefs.HasKey(Vnbjhrebwhbkqw))
            {
                PlayerPrefs.SetInt(Vnbjhrebwhbkqw, 0);
            }

            if (!PlayerPrefs.HasKey(WIoqwehonvtjk))
            {
                PlayerPrefs.SetString(WIoqwehonvtjk, "0");
                PlayerPrefs.SetInt(VNvjkrenjkq, 0);
            }

            if (!PlayerPrefs.HasKey(VOPopqjwiojruinrtji))
            {
                PlayerPrefs.SetString(
                    VOPopqjwiojruinrtji,
                    String.Join(",", new int[28])
                );
            }
        }

        public Bnjkewnrfjwebvhjrt GetLevelData(int index) =>
            _nnvjkernkjq.VNnjkwenkrq[index];

        public void IncreasePassedLevels(int currentLevel)
        {
            if (currentLevel == PassedLevels)
                PlayerPrefs.SetInt(FJKldjlkrwe, PassedLevels + 1);
        }
    }
}