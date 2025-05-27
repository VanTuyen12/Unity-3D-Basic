using System;
using UnityEngine;

public abstract class LevelAbstract : SaiMonoBehaviour
{
    //Giai quyet len lv bang cach nao
    
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    
    [SerializeField] protected int maxLevel =100;
    [SerializeField] protected int nextLevelExp;
    
    protected abstract int GetCurrentLevel();//tra ve so diem exp
    
    protected abstract bool DeductExp(int exp);//tru exp thanh cong hay k

    protected virtual void FixedUpdate()
    {
        Leveling();
    }

    protected virtual void Leveling()
    {
        if (this.currentLevel >= this.maxLevel) return;//lv hien tai >= maxlv return;
        if(this.GetCurrentLevel() < GetNextLevelExp() ) return;//exp can phai co de len lv hien tai  < moc diem exp de len lv thi return;
        if (!DeductExp(GetNextLevelExp())) return; // neu len lv ko thanh cong = false => return; => truyen vao so exp can exp can de len lv
        
        this.currentLevel++;
    }

    protected virtual int GetNextLevelExp()//diem exp can de len lv
    {
        return this.nextLevelExp = this.currentLevel * 15;
    }
}
