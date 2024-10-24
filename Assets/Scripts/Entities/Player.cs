using System;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Entities
{
    public class Player : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform borders;
        [SerializeField] private Image shipImage;

        private RectTransform _rectTransform;
        private Bnjkwenrjkwe _bnjkwenrjkwe;

        public event Action<Obstacle> OnTrigger;

        public bool IsStopped { get; set; } = false;

        public void Bootstrap(Bnjkwenrjkwe bnjkwenrjkwe)
        {
            _bnjkwenrjkwe = bnjkwenrjkwe;
        }

        private void Start()
        {
            Debug.Log($"Scren {Screen.width}");
            Debug.Log($"Rect {borders.rect.xMin} - {borders.rect.xMax}");
            _rectTransform = transform.GetComponent<RectTransform>();
        }

        public void SetShip(Sprite sprite)
        {
            shipImage.sprite = sprite;
        }

        public void Move(Vector2 position)
        {
            if (IsStopped)
                return;

            Debug.Log($"pos - {position.x}");

            float xPosition = (position.x / Screen.width - .5f) * (borders.rect.xMax - borders.rect.xMin);
            
            Debug.Log($"xPos - {xPosition}");

            xPosition = Mathf.Max(
                Mathf.Min(
                    xPosition,
                    borders.rect.xMax - 35
                ),
                borders.rect.xMin + 35
            );

            _rectTransform.anchoredPosition = new Vector2(
                xPosition,
                _rectTransform.anchoredPosition.y
            );
        }
        
        void IBeginDragHandler.OnBeginDrag(PointerEventData pointerEventData)
        {
        }

        void IDragHandler.OnDrag(PointerEventData pointerEventData)
        {
            Move(pointerEventData.position);
        }

        void IEndDragHandler.OnEndDrag(PointerEventData pointerEventData)
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTrigger.Invoke(other.gameObject.GetComponent<Obstacle>());
        }
    }
}