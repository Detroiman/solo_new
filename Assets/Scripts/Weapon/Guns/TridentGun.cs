using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentGun: Weapon
{
    [SerializeField]static int damage = 20;
    [SerializeField]static float speed = 100f;
    [SerializeField]static float weaponcd = 0.5f;
    [SerializeField]static float distance = 20f;
    public TridentGun() : base("Trident Gun", damage, speed, weaponcd, distance) { }  
    public override void WeaponStart(){ 
    }
    public override void WeaponUpdate(){ 
    }
}
