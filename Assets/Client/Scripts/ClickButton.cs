using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Client.Scripts
{

    public class ClickButton : MonoBehaviour, IPointerDownHandler
    {
        [Header("Animation")]
        [SerializeField] float _upscale = 1.1f;
        [SerializeField] float _upscaleDuration = 0.15f;
        [SerializeField] float _upscaleOvershot = 2f;
        [SerializeField] float _downscaleDuration = 0.15f;

       

        public event System.Action onClick;

        Sequence _sequence;
        IntVariable _money;

        

        

        private void Awake()
        {
            _money = FindObjectOfType<IntVariable>();
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            PlayAnimation();
            onClick?.Invoke();
        }

        private void PlayAnimation()
        {
            _sequence?.Kill();

            var s = DOTween.Sequence()
                .Append(transform.DOScale(_upscale, _upscaleDuration).SetEase(Ease.OutBack, _upscaleOvershot))
                .Append(transform.DOScale(1f, _downscaleDuration).SetEase(Ease.Linear))
                .OnKill(() => _sequence = null);
        }
    }
}