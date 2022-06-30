using UnityEngine;
using UnityEngine.Events;

public class TestInputsUsingUnityEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onSpaceDown;
    [SerializeField] private UnityEvent onMouse0Down;
    [SerializeField] private UnityEvent onMouse1Down;
    [SerializeField] private UnityEvent onMouse2Down;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) onSpaceDown.Invoke();
        if (Input.GetKeyDown(KeyCode.Mouse0)) onMouse0Down.Invoke();
        if (Input.GetKeyDown(KeyCode.Mouse1)) onMouse1Down.Invoke();
        if (Input.GetKeyDown(KeyCode.Mouse2)) onMouse2Down.Invoke();
    }
}