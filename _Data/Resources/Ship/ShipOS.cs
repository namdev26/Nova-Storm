using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Scrip Table Objects/Ship")]
public class ShipSO : ScriptableObject
{
    public string shipName = "Ship";
    public int hp = 2;    
}
