using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsManager : MonoBehaviour
{
    /* Instance */
    private static ModelsManager instance;
    public static ModelsManager Instance {get {if (instance == null) instance = FindObjectOfType<ModelsManager>(); return instance;}}
    

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject buttonContainer;


    void Start()
    {
        foreach (Item item in Resources.LoadAll("Items",typeof(Item)))
        {
            GameObject b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.GetComponent<Image>().sprite = item.ItemSprite;
            b.GetComponent<Button>().onClick.AddListener(()=>
            {
                DataManager.Instance.model=item.ItemModel;
                HolderManager.Instance.ShowHolder("Home");
            });
        }
    }
}
