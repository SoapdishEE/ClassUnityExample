using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExample
{
    void OnSceneLoaded();
    void OnStateEnter();
    void OnStateExit();
    void OnStateUpdate();
}
