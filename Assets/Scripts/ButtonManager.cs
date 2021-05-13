using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject FloorsHolder;
    [SerializeField] private GameObject ModelsHolder;
    [SerializeField] private GameObject HomeHolder;

    private void ShowHolder(string holderName)
    {
        ModelsHolder.SetActive(false);
        FloorsHolder.SetActive(false);
        HomeHolder.SetActive(false);
        if (holderName == "ModelsHolder") ModelsHolder.SetActive(true);
        if (holderName == "FloorsHolder") FloorsHolder.SetActive(true);
        if (holderName == "HomeHolder") HomeHolder.SetActive(true);
    }
    public void Btn_ShowModels() { ShowHolder("ModelsHolder"); }
    public void Btn_HideModels() { ShowHolder("HomeHolder"); }
    public void Btn_Link() { Application.OpenURL("https://www.youtube.com/watch?v=gb0QA6045mc"); }
    public void Btn_SelectModel(GameObject prefab) { DataManager.Instance.model = prefab; }
}
