using UnityEngine;

public class DefaultElement : MonoBehaviour
{
    public ElementData currentElement;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public Vector2 position;
    
    public void Refresh(ElementData newElement)
    {
        currentElement = newElement;
        SpriteRenderer.sprite = currentElement.sprite;
        
    }
    
}
