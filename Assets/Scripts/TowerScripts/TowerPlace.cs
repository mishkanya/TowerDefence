using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPlace : MonoBehaviour, IPointerClickHandler
{
    public GameObject BuildingMenu;
    public GameObject TowerInfo;
    
    [HideInInspector]
    public GameObject Tower;

    private void OnMouseDown() {
        Click();
    }
    public void OnPointerClick(PointerEventData pointerEventData){
        Click();
    }
    public void Click(){
        if(Tower != null){
            ShowInfoMenu(Tower);
        }
        else{
            ShowBuildMenu();
        }
    }
    private void ShowBuildMenu(){
        if(BuildingMenu.active == true){
            BuildingMenu.SetActive(false);
        }
        else{
            BuildingMenu.SetActive(true);
            BuildingMenu.GetComponent<TowersMenu>().Place = gameObject;
        }
    }
    private void ShowInfoMenu(GameObject Tower)
    {
        if(TowerInfo.active == true){
            TowerInfo.SetActive(false);
        }
        else{
            TowerInfo info =
            TowerInfo.GetComponent<TowerInfo>();
            info.Place = gameObject;
            info.Settings = Tower.GetComponent<TowerShoot>().Settings;
            TowerInfo.SetActive(true);
        }
    }
}
