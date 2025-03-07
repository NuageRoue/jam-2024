using UnityEngine;

public class MonsterBehaviour : CreatureBehaviour
{
    [SerializeField] MonsterType type;
    public MonsterType Type 
    {
        get { return type; }
    }
}

public enum MonsterType
{


}