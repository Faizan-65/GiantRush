using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColorSetter : MonoBehaviour
{
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        
    }

    public void SetMaterial(Material material)
    {
        if (_renderer != null)
        {
            _renderer.sharedMaterial = material;
        }
        else
        {
            Debug.LogError("Renderer component not found on GameObject " + gameObject.name);
        }
    }
}
