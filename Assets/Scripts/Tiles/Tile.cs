using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected int number;
    [SerializeField] protected int line;
    [SerializeField] protected int type;
    [SerializeField] protected GameObject structure;
    [SerializeField] protected Transform spawnPoint;
    protected int currentLevel;
    protected bool haveStructure = false;
    protected int typeStructure = 0;

    bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicke()
    {
        FindAnyObjectByType<GameManager>().ChangeTilePanel(this, true, type, typeStructure, haveStructure);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        OnClicke();
    }

    public void ChangeActive(bool act)
    {
        isActive = act;
    }

    public void BuildStructure(GameObject _structure, int typeStruct)
    {
        structure = Instantiate(_structure, spawnPoint.position, spawnPoint.rotation);
        typeStructure = typeStruct;
        haveStructure = true;
    }

    public void DestroyStructure()
    {
        haveStructure = false;
        Destroy(structure);
        structure = null;
        typeStructure = 0;
    }
}
