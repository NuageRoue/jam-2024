using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int life;

    private void Start()
    {
        life = maxLife;
    }

    public bool Hurt(int damage)
    {
        life = Mathf.Max(0, life - damage);
        return (life <= 0);
    }

    public bool Heal(int heal) 
    {
        life = Mathf.Min(life + heal, maxLife);
        return (life == maxLife);
    }

}