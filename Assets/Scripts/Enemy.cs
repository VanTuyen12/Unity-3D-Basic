using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
    {
        private int _headHp;
        //private int _maxHp = 100;
        private bool _isDead;
        private string _name;
        
        float weight = 1f;
        float minWeight = 1f;
        float maxWeight = 10f;
        public abstract string GetName();

        public virtual string GetObjName()//xuất ra tên đối tg
        {
            return gameObject.name;// giống tranform.name
        }
        private void FixedUpdate()
        {
            //this.TestClass();
        }

        
        private void OnEnable()//Gọi 1 lần khi bật tắt 1 gameObject hoặc 1 Scripts
        {
            InitData();
        }

        protected virtual void InitData()
        {
            weight = GetRamdomWeight() ;
        }

        protected virtual float GetRamdomWeight()
        {
            return Random.Range(minWeight, maxWeight);
        }
        // ReSharper disable Unity.PerformanceAnalysis
        void TestClass()
        {
            this.SetHeadHp(100);
            string logMessage = this.GetName() + " : " + this.GetHeadHp() + " : " + this.IsDead();
            Debug.Log(logMessage);
        }
        
        private int GetHeadHp()
        {
            return this._headHp;
        }

        private void SetHeadHp(int hp)
        {
            this._headHp = hp;
        }

        public virtual bool IsDead()
        {
            if (_headHp < 0) _isDead = false;
            else _isDead = true;

            return _isDead;
        }


        public virtual float GetWeight()
        {
           return this.weight;
        }
    }
