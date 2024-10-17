using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts
{
    public class SmoothClickCalculator : MonoBehaviour
    {
        [SerializeField] float _smoothCoef = 1f;

        List<float> _taps = new List<float>();
        ClickButton _clickButton;

        public float tapsPerSecond => _taps.Count;
        public float tapsPerSecondSmooth { private set; get; }

        float _velocity;

        private void Awake()
        {
            _clickButton = FindObjectOfType<ClickButton>();
        }

        private void Start()
        {
            _clickButton.onClick += _clickButton_onClick;
        }

        private void OnDestroy()
        {
            _clickButton.onClick -= _clickButton_onClick;
        }

        private void Update()
        {
            for (int i = 0; i < _taps.Count; i++)
            {
                if (_taps[i] <= Time.timeSinceLevelLoad - 1f)
                {
                    _taps.RemoveAt(i);
                }
            }

            tapsPerSecondSmooth = Mathf.SmoothDamp(tapsPerSecondSmooth, tapsPerSecond, ref _velocity, _smoothCoef);
        }



        private void _clickButton_onClick()
        {
            _taps.Add(Time.timeSinceLevelLoad);
        }
    }
}