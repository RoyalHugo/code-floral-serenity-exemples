using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendreScript : MonoBehaviour
{

    public TextMeshProUGUI Argent;
    public GameObject Progress;
    public GameObject Plant;
    public Canvas ChoosingScreen;
    public bool Reset = false;
    private bool IsDone = false;
    public Canvas ArgentBox;
    private bool ToUpdate;
    public int Currency;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            Currency = gameManager.Coins;
        }
        Argent.text = Currency.ToString();
        HideHUD();
    }

    // Update is called once per frame
    void Update()
    {
        Progressiongenerale progressiongenerale = Progress.GetComponent<Progressiongenerale>();
        int ActualProgress = progressiongenerale.CurrentProgress;
        SelectPlant vendreScript = ArgentBox.GetComponent<SelectPlant>();
        ToUpdate = vendreScript.ToUpdate;

        if (ToUpdate)
        {
            Currency = GameManager.Instance.Coins;
            Argent.text = Currency.ToString();
        }


        if (ActualProgress != 100)
        {
            Reset = false;
            IsDone = false;
        }

        if (ActualProgress == 100 && IsDone == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            IsDone = true;
        }
    }

    void OnMouseDown()
    {
        Progressiongenerale progressiongenerale = Progress.GetComponent<Progressiongenerale>();
        int ActualProgress = progressiongenerale.CurrentProgress;
        SelectPlant selectPlant = Plant.GetComponent<SelectPlant>();
        string theplant = selectPlant.WhichBox;

        Dictionary<string, int> money = new Dictionary<string, int>();

        money.Add("Plante1", 110);
        money.Add("Plante2", 90);
        money.Add("Plante3", 130);
        money.Add("Plante4", 120);
        money.Add("Plante5", 80);

        if (theplant != null && ActualProgress == 100)
        {
            GameManager.Instance.Coins += money[theplant];
            Currency = GameManager.Instance.Coins;
            Argent.text = Currency.ToString();
            HideHUD();
            Reset = true;
            ReturnChoosingScreen();
        }
    }

    void HideHUD()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void ReturnChoosingScreen()
    {
        ChoosingScreen.gameObject.SetActive(true);
    }
}
