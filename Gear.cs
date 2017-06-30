using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Gear : MonoBehaviour {

    public string title;
    public string desc;
    public Material icon;
    public int endurance;

    public abstract void setListeners(Entity owner);

}
