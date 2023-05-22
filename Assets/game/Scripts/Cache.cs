using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Cache 
{
    //transform
    private static Dictionary<GameObject, Transform> m_Transform = new Dictionary<GameObject, Transform>();
    public static Transform GetTransform(GameObject key)
    {
        if (!m_Transform.ContainsKey(key))
        {
            m_Transform.Add(key, key.GetComponent<Transform>());
        }

        return m_Transform[key];
    }

    //recttransform
    private static Dictionary<GameObject, RectTransform> m_RectTransform = new Dictionary<GameObject, RectTransform>();
    public static RectTransform GetRectTransform(GameObject key)
    {
        if (!m_RectTransform.ContainsKey(key))
        {
            m_RectTransform.Add(key, key.GetComponent<RectTransform>());
        }

        return m_RectTransform[key];
    }

    //level
    private static Dictionary<GameObject, Level> m_Level = new Dictionary<GameObject, Level>();
    public static Level GetLevel(GameObject key)
    {
        if (!m_Level.ContainsKey(key))
        {
            m_Level.Add(key, key.GetComponent<Level>());
        }

        return m_Level[key];
    }
}
