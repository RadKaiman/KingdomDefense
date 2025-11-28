using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyTxt, woodTxt, stoneTxt;
    float money, wood, stone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetMoney(1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoney(float count)
    {
        money += count;
        moneyTxt.text = money.ToString();
    }

    public float GetMoney()
    {
        return money;
    }

    public bool CanBuy(float price)
    {
        if (money >= price)
        {
            return true;
        }
        return false;
    }
}
