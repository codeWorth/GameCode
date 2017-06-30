using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    DamageTypeFire, DamageTypeWater, DamageTypeAny
}

public enum ArmorSlots
{
    ArmorHead, ArmorChest, ArmorLeg, ArmorFeet, ArmorBelt, ArmorNeck, ArmorBracers, ArmorLeftRing1, ArmorLeftRing2, ArmorRightRing1, ArmorRightRing2
}

public class Entity : MonoBehaviour {

    public int health = 500;
    public int mana = 200;
    public int stamana = 300;

    public Dictionary<ArmorSlots, Gear> armor;

    public Gear weaponMainHand { get; } = new GearEmpty();
    public Gear weaponOffHand { get; } = new GearEmpty();

    public Entity()
    {
        foreach (ArmorSlots slot in ArmorSlots.GetValues(typeof(ArmorSlots)))
        {
            armor.Add(slot, new GearEmpty());
        }
    }

    private List<TakeDamageListener> takeDamageListeners;
    public void addTakeDamageListener(TakeDamageListener listener)
    {
        takeDamageListeners.Add(listener);
    }
    public double takeDamage(double damage, DamageType type)
    {
        double newDamage = damage;

        foreach (TakeDamageListener listener in takeDamageListeners)
        {
            newDamage -= listener.takeDamage(damage, type);
        }
        if (newDamage < 0)
        {
            newDamage = 0;
        }

        health -= (int)newDamage;
        if (health <= 0)
        {
            die();
        }

        return newDamage;

    }


    public void die()
    {
        Debug.Log("Entity died");
    }

}
