using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class ShapeData
{
    //������ 3������ �ִ�.
    public enum Shape
    {
        Cube,
        Capsule,
        Sphere
    }

    //�׸��� �� �������� ��� ���, ũ��, ���� ������ �ִ�.
    public Shape shape;
    public float scale;
    public Color color;
}


public class PhysicsRaycasterTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerMoveHandler
{
    //�� ������ �ڽĿ��� �ν����Ϳ� �Է��� ������ ��������
    public ShapeData shapeData;

    //�����͸� �������� ShowToolTip����
    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystemTestManager.instance.ShowTooltip(shapeData);
    }

    //�����Ͱ� �������� ������ ShowToolTip����
    public void OnPointerExit(PointerEventData eventData)
    {
        EventSystemTestManager.instance.HideToolTip();
    }

    //�����Ͱ� �����̸� ShowToolTip����
    public void OnPointerMove(PointerEventData eventData)
    {
        EventSystemTestManager.instance.tooltip.GetComponent<RectTransform>().anchoredPosition =
            eventData.position;
        //eventData.Position : screen�� ���� �Ʒ� ���� (0, 0)�� ��ǥ �������� ���콺 �������� ��ġ
        //�� ��Ŀ�� �� Ȯ���ϰ� �ؾ��Ѵ�.
    }

    private void Start()
    {
        GetComponentInParent<Renderer>().material.color = shapeData.color;
        transform.parent.localScale = Vector3.one * shapeData.scale;
    }
}
