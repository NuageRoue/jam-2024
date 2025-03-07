using UnityEngine;

public class HeroTargetSystem : TargetSystem
{
    public override Vector3 TargetPos()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateTarget()
    {
        MonsterBehaviour[] monsters = GameObject.FindObjectsByType<MonsterBehaviour>(FindObjectsSortMode.None);

        if (monsters.Length > 0) 
        {
            SortMonsters(monsters);
            target = ClosestMonster(monsters);
        }
        else
            target = null;
    }

    // Acquire all the monsters;

    // Order them

    void SortMonsters(MonsterBehaviour[] monsters)
    {
        MonsterBehaviour temp;
        bool swapped;
        int n = monsters.Length;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (monsters[j].Type > monsters[j + 1].Type)
                {

                    // Swap arr[j] and arr[j+1]
                    temp = monsters[j];
                    monsters[j] = monsters[j + 1];
                    monsters[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no two elements were
            // swapped by inner loop, then break
            if (swapped == false)
                break;
        }
    }

    Transform ClosestMonster(MonsterBehaviour[] monsters)
    {
        if (monsters.Length == 0)
            return null;
        MonsterBehaviour toReturn = monsters[0];
        for (int i = 0; i < monsters.Length && monsters[i].Type == monsters[0].Type; i++)
        {
            if (Vector3.Distance(transform.position, monsters[i].transform.position) < Vector3.Distance(transform.position, toReturn.transform.position))
                toReturn = monsters[i];
        }
        return toReturn.transform;
    }
}