using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit =  Physics2D.Raycast(worldPos, Vector2.zero);
            
            if (hit.collider)
            {
                Debug.Log("Mouse Hit");
                //write the instructions
            }
        }
    }
}
