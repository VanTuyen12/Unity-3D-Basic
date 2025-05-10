using System.Collections.Generic;
using UnityEngine;

//where T : PoolObj có nghĩa là kiểu dữ liệu T phải là lớp PoolObj hoặc là một lớp kế thừa từ PoolObj.
public abstract class Spawner<T> : SaiMonoBehaviour where T : PoolObj 
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs;
    //Object Pooling

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual void Despawn(Transform obj)
    {
        Destroy(obj.gameObject);
    }

    public virtual T Spawn(T prefab) //Vien dan
    {

        T newObject = this.GetObjFromPool(prefab);
        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObject.transform);
        }
        return newObject;
    }

    public virtual T Spawn(T bulletPrefab, Vector3 position) //xuan hien o vitri nao(point_0,point_1)
    {
        T newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }
    
    protected virtual void RemoveObjectFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }
    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjectFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }
}