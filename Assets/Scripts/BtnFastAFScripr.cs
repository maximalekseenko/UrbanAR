using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFastAFScripr : MonoBehaviour
{
    public GameObject[] ModelSelectors;
    public GameObject[] FloorSelectors;
    public void GoogleBnt()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=gb0QA6045mc");
    }
    public void ModelsBnt()
    {
        foreach (var floor in FloorSelectors) floor.active = false;
        foreach (var model in ModelSelectors) model.active = true;
    }
    public void FloorsBnt()
    {
        foreach (var floor in FloorSelectors) floor.active = true;
        foreach (var model in ModelSelectors) model.active = false;
    }
}
