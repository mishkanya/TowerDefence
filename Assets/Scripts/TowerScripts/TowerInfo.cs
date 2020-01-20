using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfo : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [HideInInspector]
    public GameObject Place;
    [HideInInspector]
    public TowerSettings Settings;
    public TextMeshProUGUI TextAboutSell;
    private void Awake() {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable() {
        if(Place){
            _text.text = $"Attack distance: {Settings.AttackDistance}\n" + 
                        $"Damage: {Settings.Damage}\n"+ 
                        $"Shoot‌ interval‌: {Settings.ShootInterval}";
            TextAboutSell.text = $"Sell for {Settings.MoneyForSell}";
        }
    }
    public void Close(){
        this.gameObject.SetActive(false);
    }
    public void Sell(){
        GetGameController._GetGameController.Balance += Settings.MoneyForSell;
        GetGameController._GetGameController.UpdateUI();
        Destroy(Place.GetComponent<TowerPlace>().Tower);
        Close();
    }
}
