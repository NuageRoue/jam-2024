using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeSpan;

    Vector3 direction;
    float timer = 0;

    internal void AcquireTarget(Vector3 normalizedDirection, float speed)
    {
        direction = normalizedDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime;
        //movement.MoveTowards(targetSystem.TargetPos());

        if (timer >= lifeSpan)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

}