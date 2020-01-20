using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameSettings Settings;

    public Spawner MonsterSpawner;

    [Header("UI elements")]
    public TextMeshProUGUI TideText;
    public TextMeshProUGUI TideTimeText;
    public TextMeshProUGUI Money;
    public RectTransform HealthHider;

    public GameObject YouLoseHeader;
    public GameObject YouWinHeader;

    private int _tides;
    private float _timeForTide;
    private float _health;
    public int Balance;
    private const float _healthHiderWidth = 148;
    
    private  Transform[] _points;
    public  Transform[] _GetPoints{
        get
        {
            if(_points == null)
                _points = GameObject.FindGameObjectWithTag("PointsContainer").GetComponent<PointCointenier>().Points;
            return _points;
        }
    }

    private void Start() 
    {
        _timeForTide = Settings.TimeForTide;
        _health = Settings.Health;
        Balance = Settings.StartMoney;

        TideText.text = $"{_tides} / {Settings.Tides}";
        TideTimeText.text = 0.ToString();
        Money.text = Balance.ToString();
    }   
    public float ApplyDamage{
        set{
            if(_health > 0){
            Vector2 size = HealthHider.sizeDelta;
            size.x += _healthHiderWidth * (value / Settings.Health);
            HealthHider.sizeDelta = size;
            _health -= value;
            }
            else
            {
                Death();
            }
        }
    }
    
    private void Death(){
        print("ur hp is " + _health);
        Time.timeScale = 0;
        YouLoseHeader.SetActive(true);
    } 

    public void StartGame(){
        StartCoroutine(StartTide());
    }

    private IEnumerator StartTide(){
        while(_tides < Settings.Tides){
            _tides++;
            TideText.text = $"{_tides} / {Settings.Tides}";
            MonsterSpawner.TideActive(true);
            yield return new WaitForSeconds(Settings.TimeForTide);
            yield return new WaitForSeconds(Settings.PauseTime);
        }
        while(GameObject.FindGameObjectsWithTag("Enemy").Length > 0){
            yield return new WaitForSeconds(1);
        }
        Time.timeScale = 0;
        YouWinHeader.SetActive(true);
    }
    public IEnumerator Timer()
    {
        int time = Settings.TimeForTide;
        for(;;){
            time --;
            int sec = time % 60;
            int minute = (time - sec) / 60 ;
            sec = time - minute * 60;
            TideTimeText.text = $"{minute}:{sec}";
            yield return new WaitForSeconds(1);
            if(time == 0){
                yield break;
            }
        }
    }

    public void UpdateUI(){
        Money.text = Balance.ToString();
    }
}
