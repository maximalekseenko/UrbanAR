using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderManager : MonoBehaviour
{
    /* Instance */
    private static HolderManager instance;
    public static HolderManager Instance {get {if (instance == null) instance = FindObjectOfType<HolderManager>(); return instance;}}
    
    
    /* Variables */
    [SerializeField] private GameObject HomeHolder;
    [SerializeField] private GameObject ModelsHolder;
    [SerializeField] private GameObject InfoHolder;


    public void ShowHolder(string holderName)
    {
        HomeHolder.SetActive(false);
        ModelsHolder.SetActive(false);
        InfoHolder.SetActive(false);
        
        if (holderName == "Home") HomeHolder.SetActive(true);
        if (holderName == "Models") ModelsHolder.SetActive(true);
        if (holderName == "Info") InfoHolder.SetActive(true);
    }
}
