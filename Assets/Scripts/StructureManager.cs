using UnityEngine;
using System.Collections.Generic;

public class StructureManager : MonoBehaviour
{
    [SerializeField] List<GameObject> warTileStructureAll;
    [SerializeField] List<GameObject> warTileStructureAvailable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetWarTileStructure()
    {
        return warTileStructureAvailable;
    }

    public void UpdateAvailableWarTileStructure()
    {
        warTileStructureAvailable.Clear();

        foreach (GameObject cur in warTileStructureAll)
        {
            if (cur.GetComponent<StructureUI>().GetAvailable())
            {
                warTileStructureAvailable.Add(cur);
            }
        }
    }
}
