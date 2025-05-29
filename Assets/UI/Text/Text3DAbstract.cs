using System.Net;
using TMPro;
using UnityEngine;

public abstract class Text3DAbstract : SaiMonoBehaviour
{
    [SerializeField] protected TextMeshPro textPro;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
       if (textPro != null) return;
       textPro = GetComponent<TextMeshPro>();
       Debug.Log(transform.name + ": LoadTextPro", gameObject);
    }
}
