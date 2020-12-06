using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener<T> : IListenerBase
{
    void OnEventTrigger(T eventMessege);
}
