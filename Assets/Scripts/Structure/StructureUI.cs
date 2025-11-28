using UnityEngine;

public class StructureUI : MonoBehaviour
{
    [SerializeField] bool isAvailable = true;
    [SerializeField] float moneyPrice;

    [SerializeField] GameObject modelPref;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetAvailable()
    {
        return isAvailable;
    }

    public float GetMoneyPrice()
    {
        return moneyPrice;
    }

    public GameObject GetModel()
    {
        return modelPref;
    }

    public void ClickOnStructure()
    {
        FindAnyObjectByType<GameManager>().ClickStructureOnPanel(this);
    }
}
