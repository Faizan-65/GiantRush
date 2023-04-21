/*
 Attach this Script to Gameobject that has collider and rigid body attached. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PlayerController controller;
    public void OnCollisionEnter(Collision collision)
    {
        controller.CollisionEntered(collision);
    }
    public void OnTriggerEnter(Collider other)
    {
        controller.TriggerEntered(other);
    }
}
