using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts
{
    public class PassiveIncomeReward_Modifier : MonoBehaviour
    {
        [SerializeField] IntVariable _passiveIncomeReward;

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
            _passiveIncomeReward.Add(1);
        }
    }
}