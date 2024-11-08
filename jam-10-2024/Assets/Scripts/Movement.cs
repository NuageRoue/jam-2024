using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isMoving = true;
    [SerializeField] float buffSpeed = 1;
    [SerializeField] float duration = 0;
    
    
    [SerializeField] bool orientToward;
    int angle = 0;
    public void MoveTowards(Vector3 direction)
    {
        if (isMoving)
        {
            OrientToward(direction);
            transform.position += direction * speed * Time.deltaTime * buffSpeed;
        }
    }

    private void OrientToward(Vector3 direction)
    {
        if (direction.x < 0)
        {
            transform.localScale = new(-1, 1, 1);
        }
        else
        {
            transform.localScale = new(1, 1, 1);
        }
        if (orientToward)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (direction.x < 0)
                angle -= 180;
            transform.eulerAngles = new(0, 0, angle);
        }
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    

    private void Update()
    {
        CheckBuff(); 
    }

    #region buff

    void CheckBuff()
    {
        if (buffSpeed != 1 && duration > 0)
        {
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            ResetBuff();
        }
    }
    public void SetBuff(float buff, float duration)
    {
        buffSpeed = buff;
        this.duration = duration;
    }
    private void ResetBuff()
    {
        buffSpeed = 1;
        duration = 0;
    }

    #endregion buff


}