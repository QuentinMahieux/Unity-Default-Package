using System;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    public static MouseRaycast instance;
    public Camera cam;
    public ElementData data;
    public ElementData voidData;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        ChangeSelection(voidData);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit =  Physics2D.Raycast(worldPos, Vector2.zero);
            
            Debug.Log(hit.collider);
            
            if (hit.collider)
            {
                Debug.Log(hit.collider);
                hit.collider.GetComponent<DefaultElement>().Refresh(data);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit =  Physics2D.Raycast(worldPos, Vector2.zero);
            
            if (hit.collider)
            {
                hit.collider.GetComponent<DefaultElement>().Refresh(voidData);
            }
        }
    }

    public void ChangeSelection(ElementData newData)
    {
        data = newData;
    }
}
