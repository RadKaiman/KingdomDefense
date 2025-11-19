using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected int number;
    [SerializeField] protected int line;
    [SerializeField] protected string type;
    [SerializeField] protected GameObject[] structure;
    protected int currentLevel;
    protected bool haveStructure = false;
    protected int typeStructure;

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
        Debug.Log($"{line}.{number}");
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
}
