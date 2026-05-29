using UnityEngine;
using UnityEngine.UI;

public class SelectElement : MonoBehaviour
{
    public ElementData data;
    public Image sprite;
    
    
    public void Set(ElementData newData)
    {
        data = newData;

        sprite.sprite = data.sprite;
    }

    public void ChangeSelection()
    {
        MouseRaycast.instance.ChangeSelection(data);
    }
}
