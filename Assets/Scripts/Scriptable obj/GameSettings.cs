using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public int Tides;
    public float TimeForTide;

    public float Health;
    public int StartMoney;
    
}
