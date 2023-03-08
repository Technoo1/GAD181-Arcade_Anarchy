using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes { Swords, Axes, Daggers, Staves, Fists, Salmon }

[CreateAssetMenu(fileName = "Weapon", menuName = "Example/Weapon")]
public class Weapons : ScriptableObject
{
    public float weaponDamage;
    public WeaponTypes weaponType;
    public float weaponRange;
    public float weaponSpeed;
    public Color weaponColor;
}
