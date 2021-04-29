using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    Touch touch;


    void Update()
    {
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began) 
            return;
        if (IsPointerOverUI(touch)) 
            return;

        Ray ray = arCamera.ScreenPointToRay(touch.position);
        if (raycastManager.Raycast(ray, hits))
        {
            Pose pose = hits[0].pose;
            Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
        }
    }
    bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
