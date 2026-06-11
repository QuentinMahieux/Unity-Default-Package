using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSizeInterfaceElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 defaultSize = Vector3.one;
    [SerializeField] private float newSize = 1.3f;

    void Start()
    {
        defaultSize = transform.localScale;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = defaultSize * newSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = defaultSize;
    }
}
