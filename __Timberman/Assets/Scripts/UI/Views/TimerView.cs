using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace UI.Views
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Slider _timeBar;
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private Image _timeBarFill;
        
        // Color gradients for visual feedback
        [SerializeField] private Color _normalColor = Color.green;
        [SerializeField] private Color _warningColor = Color.yellow;
        [SerializeField] private Color _dangerColor = Color.red;
        [SerializeField] private float _warningThreshold = 0.5f; // 50%
        [SerializeField] private float _dangerThreshold = 0.2f;  // 20%
        
        private Slider _injectedTimeBar;
        private TextMeshProUGUI _injectedTimeText;
        
        [Inject]
        public void Construct([Inject(Id = "TimeBar", Optional = true)] Slider timeBar,
                             [Inject(Id = "TimeText", Optional = true)] TextMeshProUGUI timeText)
        {
            _injectedTimeBar = timeBar;
            _injectedTimeText = timeText;
        }
        
        private void Start()
        {
            // Use injected components if available, otherwise fallback to serialized fields
            if (_injectedTimeBar != null) _timeBar = _injectedTimeBar;
            if (_injectedTimeText != null) _timeText = _injectedTimeText;
            
            // Get fill image if not set
            if (_timeBarFill == null && _timeBar != null)
            {
                _timeBarFill = _timeBar.fillRect?.GetComponent<Image>();
            }
            
            // Initialize time bar
            if (_timeBar != null)
            {
                _timeBar.minValue = 0f;
                _timeBar.maxValue = 1f;
                _timeBar.value = 1f;
            }
        }
        
        public void UpdateTimer(float currentTime, float maxTime, float progress)
        {
            // Update time bar
            if (_timeBar != null)
            {
                _timeBar.value = progress;
                UpdateTimeBarColor(progress);
            }
            
            // Update time text
            if (_timeText != null)
            {
                _timeText.text = FormatTime(currentTime);
            }
        }
        
        public void ShowTimer()
        {
            gameObject.SetActive(true);
        }
        
        public void HideTimer()
        {
            gameObject.SetActive(false);
        }
        
        public void SetTimerActive(bool isActive)
        {
            if (_timeBar != null)
            {
                _timeBar.gameObject.SetActive(isActive);
            }
            
            if (_timeText != null)
            {
                _timeText.gameObject.SetActive(isActive);
            }
        }
        
        private void UpdateTimeBarColor(float progress)
        {
            if (_timeBarFill == null) return;
            
            Color targetColor;
            
            if (progress <= _dangerThreshold)
            {
                targetColor = _dangerColor;
            }
            else if (progress <= _warningThreshold)
            {
                // Lerp between warning and danger color
                float t = (progress - _dangerThreshold) / (_warningThreshold - _dangerThreshold);
                targetColor = Color.Lerp(_dangerColor, _warningColor, t);
            }
            else
            {
                // Lerp between normal and warning color
                float t = (progress - _warningThreshold) / (1f - _warningThreshold);
                targetColor = Color.Lerp(_warningColor, _normalColor, t);
            }
            
            _timeBarFill.color = targetColor;
        }
        
        private string FormatTime(float timeInSeconds)
        {
            if (timeInSeconds <= 0f)
                return "0:00";
                
            int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
            
            return $"{minutes}:{seconds:00}";
        }
        
        public void SetTimeBarColors(Color normal, Color warning, Color danger)
        {
            _normalColor = normal;
            _warningColor = warning;
            _dangerColor = danger;
        }
        
        public void SetWarningThresholds(float warningThreshold, float dangerThreshold)
        {
            _warningThreshold = warningThreshold;
            _dangerThreshold = dangerThreshold;
        }
    }
}
