using System;
using TMPro;
using UnityEngine;

public class TextAbstract : SaiMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }
    

    protected virtual void LoadTextPro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();

        Debug.Log(transform.name + ": LoadTextPro ", gameObject);
    }
}