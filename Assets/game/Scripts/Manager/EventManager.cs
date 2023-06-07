using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : Singleton<EventManager> 
{
    public delegate void Win();
    public delegate void Lose();
    public static event EventHandler OnWin;
    public static event EventHandler OnLose;
}
