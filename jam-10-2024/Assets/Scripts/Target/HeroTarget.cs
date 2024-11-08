using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HeroTarget : Target
{
    [SerializeField] float awarenessRadius;
    [SerializeField] LayerMask layer;
    Behaviour behaviour;
    protected override void AcquireTarget()
    {
        behaviour = GetComponent<Behaviour>();
        SelectTarget(Physics2D.OverlapCircleAll(transform.position, awarenessRadius, layer.value));
    }

    private void SelectTarget(Collider2D[] collider2Ds)
    {
        if (collider2Ds.Length == 0)
            return;
        Monster[] monsters = new Monster[collider2Ds.Length];
        for(int i = 0; i < collider2Ds.Length; i++)
        {
            monsters[i] = collider2Ds[i].GetComponent<Monster>();
        }
        Sort(monsters);
        targetToFollow = GetNearestMonster(monsters);
    }

    private Transform GetNearestMonster(Monster[] monsters)
    {
        int i = 0;
        Monster monster = monsters[0];
        Monsters type = monster.type;
        while (i < monsters.Length && monsters[i].type == type)
        {
            if (Vector3.Distance(monsters[i].transform.position, transform.position) < Vector3.Distance(monster.transform.position, transform.position))
                monster = monsters[i];
            i++;
        }

        return monster.transform;
    }

    void Sort(Monster[] monsters)
    {
        int n = monsters.Length;
        int i, j;
        Monster temp;
        bool swapped;
        for (i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                int monsterA = (int)monsters[j].type;
                if (monsters[i].isFlying && !behaviour.canAttainFlying)
                    monsterA += (int)Monsters.type9;
                int monsterB = (int)monsters[j].type;
                if (monsters[i].isFlying && !behaviour.canAttainFlying)
                    monsterB += (int)Monsters.type9;
                if (monsterA > monsterB)//collider2Ds[j] > collider2Ds[j + 1])
                {

                    // Swap arr[j] and arr[j+1]
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