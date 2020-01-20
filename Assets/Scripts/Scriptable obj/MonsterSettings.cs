using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/MonsterSettings")]
public class MonsterSettings : ScriptableObject
{
    public float Health;
    public float Speed;
    public float Damage;
    public int MoneyForKill;
    
    public Sprite Sprite;
}
