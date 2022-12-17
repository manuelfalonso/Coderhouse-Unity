using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageWheel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Image _tankImage = default;
    [SerializeField] private TextMeshProUGUI _tankDamageText = default;
    [SerializeField] private Image _wheelImage = default;

    [Header("Input Information")]
    [SerializeField] private Color _tankColor = Color.white;
    [SerializeField] private TotalDamage _tankDamage = default;

    private void Start()
    {
        _tankImage.color = _tankColor;
    }

    public void OnDamagedChanged_Handler(int newDamage)
    {
        _tankDamageText.text = $"{newDamage} %";
        _wheelImage.fillAmount = (float)newDamage / (float)_tankDamage.MaxDamage;
    }
}
