using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AObservable : MonoBehaviour, IObservable
{
    private Button button;
    private List<IObserver> observer = new();
    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(Click);
        }
        else
        {
            Debug.LogError($"Button component not found on {gameObject.name}");
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(Click);
        }
    }

    public abstract IActionClick GetAction();
    public void Click()
    {
        NotifyObservers(GetAction());
    }
    public void AddObserver(IObserver o)
    {
        observer.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observer.Remove(o);
    }

    public void NotifyObservers(IActionClick action)
    {
        observer.ForEach(o => o.UpdateAction(action));
    }
}
