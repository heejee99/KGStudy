using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    //00000000 : nothing
    //00000001 : Default 1 << 0
    //00000010 : TransparentFX 1 << 1
    //00000100 : Ignore Physics 1 << 3 (1을 2진수 기준으로 3개만큼 이동시켜라)
    //00001001 : Default, Ignore Physics 이렇게 두개의 Layer를 쓸 때도 있어서 비트플래그를 쓴다.
    //everything : -1
    public LayerMask customMask;

    private void Start()
    {
        //레이어 인덱스가 나온다.
        print($"Default Layer : {LayerMask.NameToLayer("Default")}");
        print($"TransparentFX Layer : {LayerMask.NameToLayer("TransparentFX")}");
        print($"Ignore Physics Layer : {LayerMask.NameToLayer("Ignore Physics")}");
        print($"Custom Layer Mask : {customMask.value}");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Camera.ScreenPointToRay : 해당 카메라 시점에서 스크린의 마우스 위치에서
            //카메라가 보는 방향으로 레이를 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Physics.Raycast 함수 호출시, Layer Mask를 파라미터로 명시하지 않으면
            //자동으로 Ignore Raycast 레이어는 무시함
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance: 1000f, 1 << LayerMask.NameToLayer("Ignore Physics")))
            {
                hit.collider.GetComponentInParent<Renderer>().material.color = Color.red;
            }
        }
    }
}
