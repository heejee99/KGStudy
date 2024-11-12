using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum : Int�� ������ ���谡 �ִ�.
public enum State
{
    Idle = -1,
    Move = -2,
    Attack = 8,
    Die,
}

//������� ��ø�� �����ϴ�
[Flags] //Enum�տ� Flags��� Attribute�� �߰��� ���
//�ش� Enum�� �ߺ� ������ ������ Bit Selcet ���·� ��� ����
//���� : Flags Attribute�� ������ Enum�� �� �׸��� ���� 1�� �ѹ��� ��Ʈ ���� �� ���� �ƴ� ��� ���� �۵����� ����.
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

    //���� ������ �Ʒ�ó�� ��ø�� ������� ����Ʈ�� ���� ���̴�.
    //public List<Debuff> debuffList;
    public Debuff debuff;

    private void Start()
    {
        //print($"{state} : {(int)state}");
        print($"{debuff} value : {(int)debuff}");

        print($"{debuff.HasFlag(Debuff.Poison)}");

        //�Ʒ��� HasFlag�� �Ⱦ���
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
