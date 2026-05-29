using UnityEngine;

public class FollowMouse2D : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        transform.position = mousePos;
    }
}
