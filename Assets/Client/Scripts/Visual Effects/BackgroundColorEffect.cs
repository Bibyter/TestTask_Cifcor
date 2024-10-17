using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.VisualEffects
{
    public class BackgroundColorEffect : MonoBehaviour
    {
        [SerializeField] Color _colorA;
        [SerializeField] Color _colorB;
        [SerializeField] AnimationCurve _clicksToLerp;

        Camera _camera;
        SmoothClickCalculator _smoothClickCalculator;

        private void Awake()
        {
            _smoothClickCalculator = GetComponent<SmoothClickCalculator>();
            _camera = Camera.main;
        }

        private void Update()
        {
            _camera.backgroundColor = Color.Lerp(_colorA, _colorB, _clicksToLerp.Evaluate(_smoothClickCalculator.tapsPerSecondSmooth));
        }
    }
}