using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Cards", menuName = "ScriptableObjects/Cards", order = 1)]
public class Cards : ScriptableObject
{
    //public Color pop;
    public Religion rel;

    //public enum Color { White, Black, Red, Yellow, None }
    public enum Religion { GreenTrash, YellowTrash, OrdureMenagere, Discharge, None }
    
    public SpriteRenderer sprite;
}