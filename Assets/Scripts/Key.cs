// Jenni
using System;
using UnityEngine;

public class Key : MonoBehaviour {
    [SerializeField] private KeyType type;

    #region Properties
    public KeyType Type { get; private set; }
    #endregion

    public static Color GetColor(KeyType keyType) {
        switch (keyType) {
            case KeyType.Red: return Color.red;
            case KeyType.Green: return Color.green;
            case KeyType.Blue: return Color.blue;
            case KeyType.Yellow: return Color.yellow;
            case KeyType.Black: return Color.black;
            case KeyType.Grey: return Color.grey;
            default: throw new ArgumentNullException();
        }
    }
 }
