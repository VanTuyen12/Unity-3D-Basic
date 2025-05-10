using System;
using UnityEngine;

public class Bullet : PoolObj
{
    [SerializeField] private float speed = 10f;
    

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }


    public override string GetName()
    {
        return "Bullet";
    }
}