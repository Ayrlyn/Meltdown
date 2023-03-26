using UnityEngine;


public enum Directions
{
    None = 0,
    Down = 10,
    Left = 20,
    Right = 30,
    Up = 40
}

public enum EnemyTypes
{
    Aranito,
    Blorb
}

public enum State
{
    None,
    Move,
    Attack,
    Idle,
    Push,
    Hurt
}

public enum Tag
{
    Enemy,
    Player
}
