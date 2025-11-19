using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Tile[] line1, line2, line3, line4;
    //UI
    [SerializeField] TMP_Text typeTileTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewLineActive(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewLineActive(int number)
    {
        switch (number)
        {
            case 1:
                foreach (Tile curTile in line1)
                {
                    curTile.ChangeActive(true);
                }
                break;
            case 2:
                foreach (Tile curTile in line2)
                {
                    curTile.ChangeActive(true);
                }
                break;
            case 3:
                foreach (Tile curTile in line3)
                {
                    curTile.ChangeActive(true);
                }
                break;
            case 4:
                foreach (Tile curTile in line4)
                {
                    curTile.ChangeActive(true);
                }
                break;
        }
    }
}
