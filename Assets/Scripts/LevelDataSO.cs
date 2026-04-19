using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_num", menuName = "Game/Level")]
public class LevelDataSO : ScriptableObject
{
    //determine how many line and keep lines under 5
    [SerializeField]
    private List<PassengerLines> lines;

    public List<PassengerLines> Lines
    {
        get {return lines;}
    }

    private void OnValidate()
    {
        if (lines.Count > 5)
        {
            Debug.LogWarning("Too many lines! Max is 5.", this);
            lines.RemoveRange(5, lines.Count - 5);
        }
    }

}

[System.Serializable]

public class PassengerLines
{
    //determine number of passenger in group
    [SerializeField]
    private List<PassengerLineGroup> group;

    public List<PassengerLineGroup> Group
    {
        get {return group;}
    }
}

[System.Serializable]
public class PassengerLineGroup
{
    [SerializeField] private PassengerType pType;
    [SerializeField] private int count;

    public PassengerType PType => pType;
    public int Count => count;
}

public enum PassengerType
{
    blue,
    yellow,
    red,
    green,
    purple,
}