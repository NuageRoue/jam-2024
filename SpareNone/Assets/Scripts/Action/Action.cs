using UnityEditor.PackageManager.Requests;
using UnityEngine;


public abstract class Action : MonoBehaviour
{
    [SerializeField] protected float loadTimer;
    [SerializeField] public float recoveryTime;
    float timer;
    public bool Acts()
    {
        if (timer >= loadTimer)
        {
            ResetTimer();
            PerformAction();
            return true;
        }
        timer += Time.deltaTime;
        return false;
    }


    public abstract void PerformAction();
    
    public void ResetTimer()
    { 
        timer = 0; 
    }

}