using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string title;
    public string desc;
    public Material icon;

    public DamageType type;
    public double amount;
    public bool right; //spell cast direction
}
