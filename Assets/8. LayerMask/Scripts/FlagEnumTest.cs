using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum : Int와 밀접한 관계가 있다.
public enum State
{
    Idle = -1,
    Move = -2,
    Attack = 8,
    Die,
}

//디버프는 중첩이 가능하다
[Flags] //Enum앞에 Flags라는 Attribute를 추가할 경우
//해당 Enum은 중복 선택이 가능한 Bit Selcet 형태로 사용 가능
//주의 : Flags Attribute가 부착된 Enum의 각 항목의 값은 1에 한번만 비트 연산 한 값이 아닐 경우 정상 작동하지 않음.
public enum Debuff
{
    None = 0,
    Poison = 1 << 0, //1
    Stun = 1 << 1,   //2
    Weak = 1 << 2,   //4
    Burn = 1 << 3,   //8
    Curse = 1 << 4,  //16
    Every = -1,
}

public class FlagEnumTest : MonoBehaviour
{
    public State state;

    //원래 같으면 아래처럼 중첩된 디버프를 리스트로 썼을 것이다.
    //public List<Debuff> debuffList;
    public Debuff debuff;

    private void Start()
    {
        //print($"{state} : {(int)state}");
        print($"{debuff} value : {(int)debuff}");

        print($"{debuff.HasFlag(Debuff.Poison)}");

        //아래는 HasFlag를 안쓸때
        Debuff playerDebuff = (int)Debuff.Poison + Debuff.Curse;

        Debuff cure = Debuff.Poison;

        int playerDebuffInt = (int)playerDebuff;

        //000001
        //  or
        //001000
        //  =
        //001001

        int CureInt = (int)cure;//= playerDebuffInt | (int)cure;
        print($"{playerDebuffInt == CureInt}");


        Debuff curedPlayerDebuff = (Debuff)(playerDebuffInt - CureInt);

        print(curedPlayerDebuff);
    }
}
