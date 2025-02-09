using System;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroTargetAcquisition : TargetAcquisition
{

    [SerializeField] bool canAttainFlyingEnnemy;
    public override Vector3 GetTargetPos()
    {
        return target.position;
    }

    protected override bool GetTarget()
    {
        if (target != null)
            return false;

        MonsterBehaviour[] monsters = FindObjectsOfType<MonsterBehaviour>();
        if (monsters.Length > 0 )
        { 
            OrderMonsters(monsters);
            target = NearestMonster(monsters).transform;
            return true;
        }
        return false;
        
    }

    MonsterBehaviour NearestMonster(MonsterBehaviour[] monsters)
    {
        int i = 0;
        MonsterBehaviour monster = monsters[0];
        MonsterType type = monster.type;
        while (i < monsters.Length && monsters[i].type == type)
        {
            if (Vector3.Distance(monsters[i].transform.position, transform.position) < Vector3.Distance(monster.transform.position, transform.position))
                monster = monsters[i];
            i++;
        }

        return monster;
    }

    /// <summary>
    /// order all monster by type
    /// </summary>
    /// <param name="monsters">the list of all monsters detected</param>
    void OrderMonsters(MonsterBehaviour[] monsters)
    {
        int n = monsters.Length;
        int i, j;
        MonsterBehaviour temp;
        bool swapped;
        for (i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                int monsterA = (int)monsters[j].type;
                int monsterB = (int)monsters[j].type;
                if (monsterA > monsterB)//collider2Ds[j] > collider2Ds[j + 1])
                {
                    temp = monsters[j];
                    monsters[j] = monsters[j + 1];
                    monsters[j + 1] = temp;
                    swapped = true;
                }
            }

            if (swapped == false)
                break;
        }
    }
}