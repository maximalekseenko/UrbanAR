using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ModelsManager : MonoBehaviour
{
    /* Instance */
    private static ModelsManager instance;
    public static ModelsManager Instance {get {if (instance == null) instance = FindObjectOfType<ModelsManager>(); return instance;}}
    

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;
    [SerializeField] private string label;


    async void Start()
    {
        items = new List<Item>();
        await Get(label );
        CreateButton();
    }
    void CreateButton()
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);

        }
    }

    public Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var item = await Addressables.LoadAssetAsync<Item>(location).Task;
            items.Add(item);
        }
        return null;
    }
}
