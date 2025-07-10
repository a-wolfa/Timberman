using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class TimerView : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Slider sliderBar;
        [SerializeField] private Image fillImage;

        public void SetSlider(float value)
        {
            if (sliderBar != null)
                sliderBar.value = value;
        }

        public void SetFill(float normalizedValue)
        {
            if (fillImage != null)
                fillImage.fillAmount = normalizedValue;
        }

        public void InitializeUI(float maxTime)
        {
            if (sliderBar != null)
            {
                sliderBar.minValue = 0f;
                sliderBar.maxValue = maxTime;
                sliderBar.value = maxTime;
            }

            if (fillImage != null)
                fillImage.fillAmount = 1f;
        }
    }
}