using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "")]
public class Item : ScriptableObject
{
    public GameObject ItemPrefab;
    public Sprite ItemSprite;
}
