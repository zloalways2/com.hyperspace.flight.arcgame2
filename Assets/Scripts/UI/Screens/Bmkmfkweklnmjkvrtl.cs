using System;
using System.Collections;
using Content;
using Core;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class Bmkmfkweklnmjkvrtl : VMSeklnjkVJKRvnjkrt<GamePayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text levelText;
        [SerializeField] private Transform gamePlace;
        
        private Bnjkewnrfjwebvhjrt _bnjkewnrfjwebvhjrt;
        private bool _isPaused;
        
        private Bnjkwenrjkwe _bnjkwenrjkwe;
        private Bnjkgnrjkweqw _bnjkgnrjkweqw;
        
        public void Bootstrap(
            Bnjkwenrjkwe bnjkwenrjkwe,
            Bnjkgnrjkweqw bnjkgnrjkweqw
        )
        {
            _bnjkwenrjkwe = bnjkwenrjkwe;
            _bnjkgnrjkweqw = bnjkgnrjkweqw;
        }

        public override void SetPayload(GamePayload payload)
        {
            base.SetPayload(payload);

            scoreText.text = $"SCORE: 0";
            levelText.text = $"LEVEL {payload.SelectedLevel + 1}";

            if (_bnjkewnrfjwebvhjrt != null)
            {
                _bnjkewnrfjwebvhjrt.OnWin -= Vksdhnfjkwebhjkre;
                _bnjkewnrfjwebvhjrt.OnLose -= BVNjhwerbjkrnqwejkl;
                _bnjkewnrfjwebvhjrt.OnScoreChange -= BNJKLenrkwjeq;
                _bnjkewnrfjwebvhjrt.OnTimeChange -= AWIhuiowhfvbjrtiko;
                Destroy(_bnjkewnrfjwebvhjrt.gameObject);
            }

            _bnjkewnrfjwebvhjrt = Instantiate(
                _bnjkwenrjkwe.GetLevelData(payload.SelectedLevel), 
                gamePlace
            );
            _bnjkewnrfjwebvhjrt.OnWin += Vksdhnfjkwebhjkre;
            _bnjkewnrfjwebvhjrt.OnLose += BVNjhwerbjkrnqwejkl;
            _bnjkewnrfjwebvhjrt.OnScoreChange += BNJKLenrkwjeq;
            _bnjkewnrfjwebvhjrt.OnTimeChange += AWIhuiowhfvbjrtiko;
            
            _bnjkewnrfjwebvhjrt.Bootstrap(
                BNjkewrkjhbvjhrt, 
                _bnjkwenrjkwe,
                _bnjkgnrjkweqw,
                payload.SelectedLevel);
            
            _bnjkewnrfjwebvhjrt.gameObject.SetActive(true);
        }

        public override void BNjkwnjkrwejkbvhjk()
        {
            base.BNjkwnjkrwejkbvhjk();
            
            if(_bnjkewnrfjwebvhjrt != null)
                _bnjkewnrfjwebvhjrt.StartGame();
        }

        private void Vksdhnfjkwebhjkre(int result)
        {
            _bnjkwenrjkwe.IncreasePassedLevels(_payload.SelectedLevel);
            _payload.Score = _bnjkewnrfjwebvhjrt.Score;
            _bnjkwenrjkwe.VBNjrnejkrt += _bnjkewnrfjwebvhjrt.Score;
            var results = _bnjkwenrjkwe.QGwiqgeivrt;

            results[_payload.SelectedLevel] = Math.Max(
                results[_payload.SelectedLevel],
                result
            );

            _bnjkwenrjkwe.QGwiqgeivrt = results;

            StartCoroutine(Vowiopejriojbioturio(() =>
            {
                _canvas.ChangeScreen<VMklermklntbjkty, GamePayload>(_payload);
            }));
            
        }

        private void BVNjhwerbjkrnqwejkl()
        {
            StartCoroutine(Vowiopejriojbioturio(() =>
            {
                _canvas.ChangeScreen<BNJrnfjkwejkrq, GamePayload>(_payload);
            }));
        }

        private void BNJKLenrkwjeq(int score)
        {
            scoreText.text = $"SCORE: {score}";
        }

        private void AWIhuiowhfvbjrtiko(int time)
        {
            timeText.text = $"TIME: {VNjklnekwjer.Vnjwsenjkrt(time)}";
        }

        private IEnumerator Vowiopejriojbioturio(Action callback)
        {
            yield return new WaitForSeconds(1f);
            
            callback.Invoke();
        }
    }

    public class GamePayload
    {
        public int SelectedLevel;
        public int Score;
    }
}