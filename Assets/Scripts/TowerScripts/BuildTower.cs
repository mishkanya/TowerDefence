using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class BuildTower : MonoBehaviour , IPointerClickHandler
{
    
    public TowerSettings Settings;
    private TowersMenu _menu;
    private void Start() {
        _menu = GetComponentInParent<TowersMenu>();
        GetComponentInChildren<TextMeshProUGUI>().text = $"Distance: {Settings.AttackDistance}\n" + 
                        $"Damage: {Settings.Damage}\n"+ 
                        $"Interval‌: {Settings.ShootInterval}\n" +
                        Settings.Price;
    }
    private void OnMouseDown() {
        TryBuil();
    }
    public void OnPointerClick(PointerEventData pointerEventData){
        TryBuil();
    }
    private void TryBuil(){
        if(Settings.Price <= GetGameController._GetGameController.Balance){
            _menu.Build(Settings);
        }
        else{
            print("net babaok!!!");
        }

    }

}
