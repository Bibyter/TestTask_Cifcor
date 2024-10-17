using UnityEngine;

namespace Assets.Client.Scripts
{
    public class TapRewardCalculator : MonoBehaviour
    {
        [SerializeField] float _percent = 0.1f;
        [SerializeField] IntVariable _passiveIncomeReward;
        [SerializeField] IntVariable _tapReward;

        private void OnEnable()
        {
            _passiveIncomeReward.onChange += _passiveIncomeReward_onChange;
        }

        private void OnDisable()
        {
            _passiveIncomeReward.onChange -= _passiveIncomeReward_onChange;
        }

        private void _passiveIncomeReward_onChange()
        {
            Recalculate();
        }

        private void Recalculate()
        {
            _tapReward.value = Mathf.Max(Mathf.FloorToInt(_passiveIncomeReward.value * _percent), 1);
        }
    }
}