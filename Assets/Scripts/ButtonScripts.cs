using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonScripts : MonoBehaviour
{
    public Sprite[] UISprite;
    private Image _image;
    private void Start() {
        _image = GetComponent<Image>();
    }

    private const float _multiplyTime = 2; 
    public void Pause(){
        if(Time.timeScale == 0){
            SwitchIcon(false);
            Time.timeScale = 1;
        }
        else{
            SwitchIcon(true);
            Time.timeScale = 0;   
        } 
    }
    public void MultiplyTime(){
        if(Time.timeScale == _multiplyTime){
            SwitchIcon(false);
            Time.timeScale = 1;
        }
        else{
            SwitchIcon(true);
            Time.timeScale = _multiplyTime;
        }  
    }
    private void SwitchIcon(bool useSprite){
        if(useSprite){
            _image.sprite = UISprite[1];
        }
        else
            _image.sprite = UISprite[0];
    }
}
