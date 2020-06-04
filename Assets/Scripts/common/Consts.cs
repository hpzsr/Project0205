using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 英雄配置表字段
public class HeroEntityData
{
    public int id;
    public string name;
    public string level;
    public int star;
    public int needSeat;
    public int hp;
    public int shuijing;
    public int defense_guangsu;
    public int defense_gedou;
    public int defense_shidan;
    public int huibi_rate;
    public int jidongli;
    public int en_max;
    public int en_huifu;
    public int fanji_rate;
    public int zhuiji_rate;
}

public class HeroData
{
    public float hp = 0;
    public float en = 0;
}

public class Consts
{
    public enum HeroState
    {
        idle,
        walk,
        run,
        jump,
        die,
        atk1,
        atk2,
        atk3,
        atk4,
        damage
    }

    public enum FrameAnimationSpeed
    {
        low,
        normal,
        quick,
    }

    public enum MoveDirection
    {
        left,
        right,
    }

    public enum SeatState
    {
        wait,
        choice,
        used,
    }
}
