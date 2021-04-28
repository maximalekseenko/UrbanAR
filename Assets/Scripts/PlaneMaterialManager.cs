using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneMaterialManager : MonoBehaviour
{
    public Material planeMaterial;
    public Button[] planeTextureButtons;
    public Button[] ModelButtons;

    void Awake() {
        foreach (var button in planeTextureButtons) {
            Texture texture = button.transform.Find("Mask/RawImage").GetComponent<RawImage>().texture;
            button.onClick.AddListener(()=>OnClickButton(texture));
        }
    }

    void Update(){
        
    }

    void OnClickButton(Texture texture) {
        planeMaterial.mainTexture = texture;
    }
}
