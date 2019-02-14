using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

// 우선 여기에 놓고 .. 

/// <summary>
///  Controll Unity EngineUI ( Text , Image ) 
///  It Holds UIComponents As a  Dictionary 
/// </summary>
public class UIHandler
{
    Dictionary<string, UnityEngine.Object> UIComponentsDict = new Dictionary<string, UnityEngine.Object>();

    private static UIHandler instance;
    public static UIHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIHandler();
                instance.Initialize();
            }
            return instance;
        }
    }


    public void Initialize()
    {
        //todo do some stuff
    }

    /// <summary>
    /// TODO Need To Call If Scene Changed....
    /// Destory this instance.
    /// </summary>
    public void Destory()
    {
        //todo do some stuff
        instance = null;
    }

    public void EnrollUIComponent(Text textComponent, string Id)
    {
        if (!UIComponentsDict.ContainsKey(Id))
        {
            UIComponentsDict.Add(Id, textComponent);
        }
        else
        {
            throw new Exception("Duplicated Enroll for UI Component");
        }
    }

    public void EnrollUIComponent(Image imageComponent, string Id)
    {
        if (!UIComponentsDict.ContainsKey(Id))
        {
            UIComponentsDict.Add(Id, imageComponent);
        }
        else
        {
            throw new Exception("Duplicated Enroll for UI Component");
        }
    }

    public void SetUIContent(Sprite spriteOrNull, string targetId)
    {
        if (!UIComponentsDict.ContainsKey(targetId)) throw new Exception("No Component Enrolled Matches ID : " + targetId);
        if (!(UIComponentsDict[targetId] is Image)) throw new Exception("Wrong Content Type for Component : " + targetId);
        var component = (Image)UIComponentsDict[targetId];
        component.sprite = spriteOrNull;
    }

    public void SetUIContent(string stringOrNull, string targetId)
    {
        if (!UIComponentsDict.ContainsKey(targetId)) throw new Exception("No Component Enrolled Matches ID : " + targetId);
        if (!(UIComponentsDict[targetId] is Text)) throw new Exception("Wrong Content Type for Component : " + targetId);
        var component = (Text)UIComponentsDict[targetId];
        component.text = stringOrNull;
    }

    public void SetActive(string targetId, bool isActive)
    {
        if (!UIComponentsDict.ContainsKey(targetId)) throw new Exception("No Component Enrolled Matches ID : " + targetId);
        var component = UIComponentsDict[targetId];
        GameObject gameObjectTarget = null;
        if (component is Text) ((Text)component).gameObject.SetActive(isActive);
        else if (component is Image) ((Image)component).gameObject.SetActive(isActive);
        else throw new Exception("Wrong Type of Component id : " + targetId);
    }

    public GameObject GetGameObjectWithTargetComponent(string targetId)
    {
        if (!UIComponentsDict.ContainsKey(targetId)) throw new Exception("No Component Enrolled Matches ID : " + targetId);
        var component = UIComponentsDict[targetId];
        GameObject gameObjectTarget = null;
        if (component is Text) return ((Text)component).gameObject;
        else if (component is Image) return ((Image)component).gameObject;
        else throw new Exception("Wrong Type of Component id : " + targetId);
    }
}

