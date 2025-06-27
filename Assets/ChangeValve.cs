using UnityEngine;
using UnityEngine.Events;

public class ChangeValve : MonoBehaviour
{
    public UnityEvent onValveChange; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        onValveChange?.Invoke();
    }
}
