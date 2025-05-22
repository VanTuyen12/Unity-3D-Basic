using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : SaiMonoBehaviour
{
    [SerializeField] protected Button button;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    public virtual void AddOnClickEvent()
    {
       button.onClick.AddListener(OnClick);
    }
    
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = this.GetComponent<Button>();
        
        Debug.Log(transform.name + " :LoadButton ",gameObject);
    }
    
    public abstract void OnClick();
}
