using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<Material> pallet = new List<Material>();
    public int levelLength=3;
    public GameObject first;
    public GameObject end;
    public List<GameObject> chunks = new List<GameObject>();
    public GameObject levelParent;
    public Transform poser;
    


    [HideInInspector] public Vector3 endPosition;
    public Material firstMaterial;
    
    private CHUNK_TYPE chunkType;
    private Color color;

    private void Start()
    {
        GenerateLevel();
    }
    public LevelGenerator GenerateLevel()
    {
        if (levelParent.transform.childCount > 0)
        {
            poser.transform.position = Vector3.zero;
            poser.transform.eulerAngles=new Vector3(0,270,0); //this line is important and shouldn't be changed
        }
        //spawn first zero
        GameObject zero = Instantiate(first, levelParent.transform);
        zero.transform.position = poser.position;
        zero.transform.eulerAngles = poser.eulerAngles;
        poser = zero.GetComponent<Chunk>().end;
        chunkType = zero.GetComponent<Chunk>().chunkType;
        int y = 0;
        //spawn Array
        for (int i = 0; i < levelLength; i++)
        {
            int counter = 0;
            int x;
            do
            {
                x = Random.Range(0, chunks.Count);
                counter++;
                if (counter>500)
                {
                    Debug.Log("Broke");
                    break;
                }
            }
            while (chunks[x].GetComponent<Chunk>().chunkType == chunkType);


            
            if (chunks[x].GetComponent<Chunk>().chunkType == CHUNK_TYPE.Circle)
            {
                y = Random.Range(0, pallet.Count);
                chunks[x].GetComponent<CircleColorSetter>().SetMaterial(pallet[y]);
            }
            
            if (chunks[x].GetComponent<Chunk>().chunkType==CHUNK_TYPE.Straight)
            {
                Debug.Log(pallet[y].name);
                chunks[x].GetComponent<FoodPlacement>().PlaceFood(pallet[y], pallet[(y+1)%pallet.Count]);

            }
            GameObject inst = Instantiate(chunks[x], levelParent.transform);
            inst.transform.position = poser.position;
            inst.transform.eulerAngles = poser.eulerAngles;
            poser = inst.GetComponent<Chunk>().end;
            chunkType=inst.GetComponent<Chunk>().chunkType;
        }
        //spawn end level
        GameObject last = Instantiate(end, levelParent.transform);
        last.transform.position = poser.position;
        last.transform.eulerAngles = poser.eulerAngles;
        endPosition = last.transform.position;
        return this;
    }
    public void ButtonCall()
    {
        GenerateLevel();
    }
}
