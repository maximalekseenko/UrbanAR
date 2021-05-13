using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance { get { if (instance == null) instance = FindObjectOfType<DataManager>(); return instance; } }


    public GameObject model;
}