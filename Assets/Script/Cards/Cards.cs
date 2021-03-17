using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Cards", menuName = "ScriptableObjects/Cards", order = 1)]
public class Cards : ScriptableObject
{
    //public Color pop;
    public Garbage grb;

    //public enum Color { White, Black, Red, Yellow, None }
    public enum Garbage { GreenTrash, YellowTrash, OrdureMenagere, Discharge }
    
    public SpriteRenderer sprite;
    public Color color;
    public string def;
}