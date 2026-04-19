using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Passenger_type", menuName = "Passenger/Type")]
public class PassengerSO : ScriptableObject
{
    [SerializeField]
    private PassengerType type;
    [SerializeField]
    private Color color;
    [SerializeField]
    private Sprite sprite;
}
