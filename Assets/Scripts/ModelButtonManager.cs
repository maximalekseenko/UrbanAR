using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModelButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject furniture;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectSpawnObject);
    }

    void SelectSpawnObject() {
        DataHandler.Instance.furniture = furniture;
    }
}
