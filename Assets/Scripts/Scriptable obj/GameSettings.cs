using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public int Tides;
    public int TimeForTide;
    public float PauseTime;
    public float Health;
    public int StartMoney;
    
}
