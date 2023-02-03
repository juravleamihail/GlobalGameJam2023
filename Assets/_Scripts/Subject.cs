using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<IObservable> Observers = new();

    public void Subscribe(IObservable newObserver)
    {
        Observers.Add(newObserver);
    }

    public void Unsubscribe(IObservable observer)
    {
        Observers.Remove(observer);
    }

    protected void NotifyObservers()
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify();
        }
    }
}
