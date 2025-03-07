using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int life;
    [SerializeField]
    public int HP
    {
        get { return life; }
    }

    public bool TakeDamage(int damage)
    {
        life = (life - damage <= 0) ? 0 : life - damage;
        return life == 0;
    }

    public bool Heal(int health)
    {
        life = (life + health >= maxLife) ? maxLife : life + health;
        return life == maxLife;
    }
}