using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMotion : MonoBehaviour
{
    [SerializeField] private float speedFwd;

    public void Move()
    {
        transform.position += transform.forward * speedFwd * Time.deltaTime;
    }

}
