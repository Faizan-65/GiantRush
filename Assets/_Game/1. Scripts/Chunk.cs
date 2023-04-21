using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chunk : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public CHUNK_TYPE chunkType;
}

public enum CHUNK_TYPE
{
    Straight, Circle
}