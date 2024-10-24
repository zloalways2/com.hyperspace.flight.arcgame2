using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Content;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities
{
    public class Bnjkewnrfjwebvhjrt : MonoBehaviour
    {
        [SerializeField] private int time = 10;
        [SerializeField] private Player player;
        [SerializeField] private Barrier[] barriers;
        [SerializeField] private Diamond diamond;
        [SerializeField] private int VMKLewmklemlvrt = 50;
        [SerializeField] private float diamondSpawnChance = .4f;
        [SerializeField] private float[] spawnDurationRange = { .2f, .6f };
        [SerializeField] private RectTransform spawnArea;

        private int _score = 0;
        private float _passedTime = 0;
        private int _level = 0; 
        private bool _isLocked = false;
        private List<Obstacle> _obstacles = new List<Obstacle>();
        private BNjkewrkjhbvjhrt _bNjkewrkjhbvjhrt;
        private Coroutine _spawningCoroutine;
        private Coroutine _timerCoroutine;
        private Bnjkgnrjkweqw _bnjkgnrjkweqw;
        private Bnjkwenrjkwe _bnjkwenrjkwe;

        public event Action<int> OnScoreChange;
        public event Action<int> OnTimeChange;
        public event Action<int> OnWin;
        public event Action OnLose;

        public int Score => _score;

        public void Bootstrap(
            BNjkewrkjhbvjhrt bNjkewrkjhbvjhrt, 
            Bnjkwenrjkwe bnjkwenrjkwe,
            Bnjkgnrjkweqw bnjkgnrjkweqw,
            int level)
        {
            _bNjkewrkjhbvjhrt = bNjkewrkjhbvjhrt;
            _level = level;
            _bnjkgnrjkweqw = bnjkgnrjkweqw;
            _bnjkwenrjkwe = bnjkwenrjkwe;
            time += 10 * _level;
            
            player.Bootstrap(bnjkwenrjkwe);
        }

        private void Start()
        {
            player.OnTrigger += OnPlayerTrigger;
        }

        public void StartGame()
        {
            player.SetShip(_bnjkgnrjkweqw.VBbnjrewbkj[_bnjkwenrjkwe.BNjkenwkjrkjq]);
            
            _spawningCoroutine = StartCoroutine(VBMskemfklwerjklb());

            foreach (var obstacle in _obstacles)
            {
                obstacle.IsStopped = false;
            }

            player.IsStopped = false;

            _timerCoroutine = StartCoroutine(TickTime());
        }

        public void StopGame()
        {
            StopCoroutine(_spawningCoroutine);
            StopCoroutine(_timerCoroutine);

            foreach (var obstacle in _obstacles)
            {
                obstacle.IsStopped = true;
            }

            player.IsStopped = true;
        }

        private void OnPlayerTrigger(Obstacle obj)
        {
            if (obj.GetType() == typeof(Barrier))
            {
                _bNjkewrkjhbvjhrt.OnLose();
                StopGame();
                OnLose.Invoke();
                return;
            }

            _score += VMKLewmklemlvrt;
            Destroy(obj.gameObject);
            _bNjkewrkjhbvjhrt.OnCoinCollect();
            OnScoreChange?.Invoke(_score);
        }

        private IEnumerator VBMskemfklwerjklb()
        {
            while (true)
            {
                Obstacle spawningSphere = Random.value <= diamondSpawnChance
                    ? (Obstacle) diamond
                    : barriers[(int)(Random.value * 10) % barriers.Length];

                Obstacle spawned = Instantiate(
                    spawningSphere,
                    spawnArea
                );
                _obstacles.Add(spawned);

                spawned.transform.localPosition = Vector3.right * Random.Range(
                    spawnArea.rect.xMin,
                    spawnArea.rect.xMax
                );

                yield return new WaitForSeconds(Random.Range(spawnDurationRange[0], spawnDurationRange[1]));
            }
        }
        
        private IEnumerator TickTime()
        {
            while (true)
            {
                _passedTime += Time.deltaTime;
                
                OnTimeChange.Invoke((int) (time - _passedTime));

                if (_passedTime >= time)
                {
                    _isLocked = true;
                    StopGame();
                    _bNjkewrkjhbvjhrt.OnWin();
                    OnWin.Invoke(Math.Max(
                        (int)Math.Ceiling((float)_score / VMKLewmklemlvrt /
                            _obstacles.Sum(o => o.GetType() == typeof(Diamond)
                                ? 1
                                : 0
                            ) * 3 * 1.1), 3)
                    );
                    break;
                }

                yield return null;
            }
        }
    }
}