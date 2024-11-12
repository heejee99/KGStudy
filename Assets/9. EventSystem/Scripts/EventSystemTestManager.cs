using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventSystemTestManager : MonoBehaviour
{
    public static EventSystemTestManager instance;

    public TextMeshProUGUI text;

    public Tooltip tooltip;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HideToolTip();
    }

    //TooltipŬ������ �����ͼ� SetData�� �Է��ϴµ�, ���⼭ �Է��ϴ� data�� ShapeData���� ������ ���̴�.
    public void ShowTooltip(ShapeData data)
    {
        tooltip.SetData(data);
        tooltip.gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        tooltip.gameObject.SetActive(false);
    }
}
