using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour
{
    protected Movement movement;
    protected TargetAcquisition targetAcquisition;
    protected Action action;
    protected Life life;
    protected Knockback knockBack;
    public bool isFlying;
    Rigidbody2D rb;

    [SerializeField] float stunTimer = 0;


    
    [SerializeField] float weight;
    [SerializeField] float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        targetAcquisition = GetComponent<TargetAcquisition>();
        action = GetComponent<Action>();
        life = GetComponent<Life>();
        knockBack = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        stunTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            action.ResetTimer();
        }
        else
        {
            if (movement == null || movement.MoveTowards(targetAcquisition.GetTargetPos(), radius))
            {
                // performAction on the target
                if (action.Act())
                {
                    Stun(action.waitTime);
                }
            }
            else
            {
                action.ResetTimer();
            }
        }
    }

    public void Hurt(int damage)
    {
        Debug.Log(name + ": receives " + damage + " points of damage");
        life?.Hurt(damage);
    }
    
    public void Heal(int health)
    {
        if (life != null)
            life.Heal(health);
    }

    public void Push(int strength, Vector3 direction)
    {
        if (knockBack != null && (strength - weight) > 0)
        {
            Debug.Log(name + ": being pushed");
            knockBack.Push(strength - weight, direction);
            Stun(knockBack.StunDuration(strength - weight));
        }
    }

    public void Stun(float duration)
    {
        Debug.Log(name + " is stun for " + duration + " seconds");
        stunTimer += duration;
    }
}