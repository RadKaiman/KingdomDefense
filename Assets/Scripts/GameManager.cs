using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ResourceManager resourceManager;

    [SerializeField] Tile[] line1, line2, line3, line4;
    //UI
    [SerializeField] GameObject tilePanel;
    [SerializeField] GameObject structurePanel;
    [SerializeField] GameObject buttonCreate, buttonDestroy, buttonConfirm;
    [SerializeField] TMP_Text typeTileTxt, typeStructureTxt, confirmationTxt;
    [SerializeField] Sprite checkSprite, crossSprite;
    [SerializeField] Transform containerStructure;
    List<GameObject> currentStructureUI;
    //Tile
    Tile currentTile;
    int currentType;
    int currentTypeStructure;
    //Structure
    StructureManager structureManager;
    StructureUI currentStructure;
    bool canBuild = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = FindAnyObjectByType<ResourceManager>();
        structureManager = FindAnyObjectByType<StructureManager>();
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

    string NameStructureType()
    {
        string name = "";
        switch (currentTypeStructure)
        {
            case 0:
                name = "None";
                break;
            case 1:
                name = "Tower_lvl_1";
                break;
            case 2:
                name = "Tower_lvl_2";
                break;
        }
        return name;
    }

    string NameType()
    {
        string name = "";
        switch (currentType)
        {
            case 0:
                name = "None";
                break;
            case 1:
                name = "War Tile";
                break;
            case 2:
                name = "Road";
                break;
        }
        return name;
    }

    public void ChangeTilePanel(Tile tile = null, bool active = false, int tileType = 0, int structureType=0, bool haveStructure = false)
    {
        currentTile = tile;
        currentType = tileType;
        currentTypeStructure = structureType;
        typeTileTxt.text = NameType();
        typeStructureTxt.text = NameStructureType();
        tilePanel.SetActive(active);
        buttonCreate.SetActive(!haveStructure);
        buttonDestroy.SetActive(haveStructure);
        structurePanel.SetActive(false);

        if (currentStructureUI != null)
        {
            for (int i = currentStructureUI.Count - 1; i >= 0; i--)
            {
                GameObject cur = currentStructureUI[i];
                Destroy(cur);
            }
            currentStructureUI.Clear();
        }
        canBuild = false;
        buttonConfirm.GetComponent<Image>().sprite = crossSprite;
        buttonConfirm.GetComponent<Button>().interactable = false;
        confirmationTxt.text = "Not selected";
    }

    public void CloseTilePanel()
    {
        tilePanel.SetActive(false);
        structurePanel.SetActive(false);

        if (currentStructureUI != null)
        {
            for (int i = currentStructureUI.Count - 1; i >= 0; i--)
            {
                GameObject cur = currentStructureUI[i];
                Destroy(cur);
            }
            currentStructureUI.Clear();
        }
        canBuild = false;
        buttonConfirm.GetComponent<Image>().sprite = crossSprite;
        buttonConfirm.GetComponent<Button>().interactable = false;
        confirmationTxt.text = "Not selected";
    }

    public void ClickBuildButton()
    {
        structurePanel.SetActive(!structurePanel.activeSelf);
        if (structurePanel.activeSelf)
        {
            UpdateStructure();
        }
        else
        {
            if (currentStructureUI != null)
            {
                for (int i = currentStructureUI.Count - 1; i >= 0; i--)
                {
                    GameObject cur = currentStructureUI[i];
                    Destroy(cur);
                }
                currentStructureUI.Clear();
            }
            canBuild = false;
            buttonConfirm.GetComponent<Image>().sprite = crossSprite;
            buttonConfirm.GetComponent<Button>().interactable = false;
            confirmationTxt.text = "Not selected";
        }
    }

    void UpdateStructure()
    {
        switch (currentType)
        {
            case 1:
                structureManager.UpdateAvailableWarTileStructure();
                List<GameObject> curList = structureManager.GetWarTileStructure();
                foreach (GameObject cur in curList)
                {
                    currentStructureUI.Add(Instantiate(cur, containerStructure, false));
                }
                break;
            case 2:
                //Дорожная клетка
                break;
        }
    }

    public void ClickStructureOnPanel(StructureUI structur)
    {
        currentStructure = structur;
        if (resourceManager.CanBuy(currentStructure.GetMoneyPrice()))
        {
            canBuild = true;
            buttonConfirm.GetComponent<Image>().sprite = checkSprite;
            buttonConfirm.GetComponent<Button>().interactable = true;
            confirmationTxt.text = "Build";
        }
        else
        {
            canBuild = false;
            buttonConfirm.GetComponent<Image>().sprite = crossSprite;
            buttonConfirm.GetComponent<Button>().interactable = false;
            confirmationTxt.text = "Not enough money";
        }
    }

    public void TryBuild()
    {
        if (!canBuild)
        {
            return;
        }
        currentTile.BuildStructure(currentStructure.GetModel(), currentStructure.GetModel().GetComponent<Structure>().GetTypeStructure());
    }

    public void ClickDestroyButton()
    {
        currentTile.DestroyStructure();
    }
}
