using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class ShapeData
{
    //도형은 3가지가 있다.
    public enum Shape
    {
        Cube,
        Capsule,
        Sphere
    }

    //그리고 각 도형들은 모두 모양, 크기, 색을 가지고 있다.
    public Shape shape;
    public float scale;
    public Color color;
}


public class PhysicsRaycasterTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerMoveHandler
{
    //각 도형의 자식에서 인스펙터에 입력한 값들을 가져오고
    public ShapeData shapeData;

    //포인터를 가져오면 ShowToolTip실행
    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystemTestManager.instance.ShowTooltip(shapeData);
    }

    //포인터가 도형에서 나가면 ShowToolTip실행
    public void OnPointerExit(PointerEventData eventData)
    {
        EventSystemTestManager.instance.HideToolTip();
    }

    //포인터가 움직이면 ShowToolTip실행
    public void OnPointerMove(PointerEventData eventData)
    {
        EventSystemTestManager.instance.tooltip.GetComponent<RectTransform>().anchoredPosition =
            eventData.position;
        //eventData.Position : screen의 왼쪽 아래 끝이 (0, 0)인 좌표 기준으로 마우스 포인터의 위치
        //즉 엥커를 잘 확인하고 해야한다.
    }

    private void Start()
    {
        GetComponentInParent<Renderer>().material.color = shapeData.color;
        transform.parent.localScale = Vector3.one * shapeData.scale;
    }
}
