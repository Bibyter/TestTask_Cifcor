using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.VisualEffects
{
    public class ClickParticles : MonoBehaviour
    {
        ClickButton _clickButton;

        private void Awake()
        {
            _clickButton = FindObjectOfType<ClickButton>();
        }

        private void OnEnable()
        {
            _clickButton.onClick += _clickButton_onClick;
        }

        private void OnDisable()
        {
            _clickButton.onClick -= _clickButton_onClick;
        }

        private void _clickButton_onClick()
        {
            var emitParams = new ParticleSystem.EmitParams();
            GetComponent<ParticleSystem>().Emit(emitParams, 10);
        }
    }
}