using UnityEngine;
using UnityEngine.EventSystems;
public class CubeEvent360 : EventTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("Pointer").GetComponent<pointer360>().Active();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Pointer").GetComponent<pointer360>().Desactive();
    }
}
