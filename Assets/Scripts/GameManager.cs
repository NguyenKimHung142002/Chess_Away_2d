using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Level Setting")]
    [SerializeField] private LevelDataSO levelData;

    [Header("Prefabs")]
    [SerializeField] private GameObject passengerPrefab;
    [SerializeField] private GameObject linePrefab;

    [Header("UI")]
    [SerializeField] private Transform lineContaner;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLine(levelData);
    }

    private void GenerateLine(LevelDataSO levelData)
    {
        for (int i = 0; i < levelData.Lines.Count; i++)
        {
            var line = levelData.Lines[i].Group;
            GameObject lineObject = Instantiate(linePrefab, lineContaner);
            foreach (PassengerLineGroup group in line)
            {
                GeneratePassenger(group, passengerPrefab, lineObject.transform);
            }
        }
    }

    private void GeneratePassenger(PassengerLineGroup group, GameObject pPrefab, Transform parent)
    {
        for (int i = 0; i < group.Count; i++)
        {
            GameObject passenger = Instantiate(pPrefab, parent);

            passenger.GetComponent<Image>().color = PassengerTypeToColor(group.PType);
        }
    }

    Color PassengerTypeToColor(PassengerType type)
    {
        switch (type)
        {
            case PassengerType.blue: return Color.blue;
            case PassengerType.red: return Color.red;
            case PassengerType.yellow: return Color.yellow;
            case PassengerType.green: return Color.green;
            case PassengerType.purple: return Color.magenta;
        }
        return Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
