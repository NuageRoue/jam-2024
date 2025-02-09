using DigitalRuby.Tween;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //TODO: weight is a float; 


    [SerializeField] float duration;
    [SerializeField] float stunFactor;
    [SerializeField] float speed;
    [SerializeField] float angle;


    public float StunDuration(float strength)
    {
        return duration + strength * stunFactor;
    }

    


    public void Push(float strength, Vector3 normalizedDirection)
    {
        //TODO: rotate a bit the normalized direction so that it's a bit random
        System.Action<ITween<Vector3>> Push = (t) =>
        {
            transform.position += t.CurrentValue;
        };

        Vector3 movement = strength * duration * RotateDirection(normalizedDirection);
        gameObject.Tween(null, Vector3.zero, movement, duration, TweenScaleFunctions.CubicEaseOut, Push);
        Debug.Log(name + " is being pushed on a distance of" + Vector3.Distance(transform.position, transform.position + movement));

    }

    Vector3 RotateDirection(Vector3 direction) 
    {
        float theta = Random.Range(0,1f) > .5f?-Random.Range(0, angle * Mathf.Deg2Rad): Random.Range(0, angle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(theta);
        float sin = Mathf.Sin(theta);
        return new Vector3(direction.x * cos - direction.y * sin, direction.x * sin + direction.y * cos);
    }
}