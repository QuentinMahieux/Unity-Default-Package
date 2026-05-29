using UnityEngine;

public class ElementStudio : MonoBehaviour
{
    public ElementData element;
    public SpriteRenderer SpriteRenderer;

    public void Refresh(ElementData newElement)
    {
        element = newElement;
        SpriteRenderer.sprite = element.sprite;
    }
}
