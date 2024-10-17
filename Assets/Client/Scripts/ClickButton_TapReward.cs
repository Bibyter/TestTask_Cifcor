using UnityEngine;

namespace Assets.Client.Scripts
{

    public class ClickButton_TapReward : MonoBehaviour
    {
        ClickButton _clickButton;
        IntVariable _money;
        IntVariable _passiveIncomeReward;


        private void Awake()
        {
            _clickButton = FindObjectOfType<ClickButton>();
            _money = IntVariable.GetVariable("Money");
            _passiveIncomeReward = IntVariable.GetVariable("Passive Income Reward");
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
            _money.Add(_passiveIncomeReward.value);
        }
    }
}