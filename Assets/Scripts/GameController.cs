using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameSettings _settings;

    public TextMeshProUGUI TideText;
    public TextMeshProUGUI TideTimeText;
    public TextMeshProUGUI Money;
    public RectTransform HealthHider;

    private int _tides;
    private float _timeForTide;
    private float _health;
    private int _money;
    private const float _healthHiderWidth = 148;

    private void Start() 
    {
        _timeForTide = _settings.TimeForTide;
        _health = _settings.Health;
        _money = _settings.StartMoney;

        TideText.text = $"{_tides} / {_settings.Tides}";
        TideTimeText.text = 0.ToString();
        Money.text = _money.ToString();
    }   
    public float ApplyDamage{
        set{
            Vector2 size = HealthHider.sizeDelta;
            size.x += _healthHiderWidth * (value / _settings.Health);
            HealthHider.sizeDelta = size;
            _health -= value;
            if(_health <= 0){
                Death();
            }
        }
    }
    private void Death(){
        print("ur hp is " + _health);
    } 
}
