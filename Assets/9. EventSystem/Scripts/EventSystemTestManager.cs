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

    //Tooltip클래스를 가져와서 SetData를 입력하는데, 여기서 입력하는 data도 ShapeData에서 가져온 것이다.
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
