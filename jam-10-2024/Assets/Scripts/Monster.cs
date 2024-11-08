using UnityEngine;

public enum Monsters
{
    none,
    type0,
    type1,
    type2,
    type3,
    type4,
    type5,
    type6,
    type7,
    type8,
    type9
}

public class Monster : Behaviour
{
    public Monsters type;
}