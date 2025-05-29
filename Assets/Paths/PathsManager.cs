using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paths
{
    public class PathsManager : SaiSingleton<PathsManager>
    {
        [SerializeField]List<PathMoving> paths = new();

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPaths();
            
        }
        
        protected virtual void LoadPaths()
        {
            if (this.paths.Count > 0) return;

            foreach (Transform child in transform)
            {
                PathMoving path = child.GetComponent<PathMoving>();
                path.LoadPoints();//Goi loadPoint cho tien cx dc
                this.paths.Add(path);
            }
            
            Debug.Log(transform.name + ":LoadPaths" , gameObject);
        }

        public virtual PathMoving GetPath(int index)//Tim Kiem bang Index
        {
            return this.paths[index];
        }

        public virtual PathMoving GetPath(string pathName) // Tim kiem bang Name Path
        {
            foreach (PathMoving path in this.paths)
            {
                if (path.name == pathName)
                    return path;
            }
            return null;
        }
    }
}