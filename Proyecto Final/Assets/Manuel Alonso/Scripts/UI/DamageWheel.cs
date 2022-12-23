using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DamageWheel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Image _tankImage = default;
    [SerializeField] private TextMeshProUGUI _remainingLivesText = null;
    [SerializeField] private TextMeshProUGUI _tankDamageText = default;
    [SerializeField] private Image _wheelImage = default;

    [Header("Input Information")]
    [SerializeField] private Color _tankColor = Color.white;
    [SerializeField] private TotalDamage _tankDamage = default;

    private Respawn _myRespawnScript = default;

    private void Start()
    {
        _tankImage.color = _tankColor;
        if (_tankDamage.TryGetComponent<Respawn>(out Respawn component))
        {
            _myRespawnScript = component;
            _remainingLivesText.text = $"x{_myRespawnScript.Lifes}";
            _myRespawnScript.OnLifeLost.AddListener(OnLifeLost_Handler);
        }
    }

    private void OnLifeLost_Handler()
    {
        _remainingLivesText.text = $"x{_myRespawnScript.Lifes}";
    }

    public void OnDamagedChanged_Handler(int newDamage)
    {
        _tankDamageText.text = $"{newDamage} %";
        _wheelImage.fillAmount = (float)newDamage / (float)_tankDamage.MaxDamage;
    }
}
