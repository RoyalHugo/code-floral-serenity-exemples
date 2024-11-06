using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelectPlant : MonoBehaviour
{

    public string WhichBox = null;
    public GameObject RemoveBox;
    public TextMeshProUGUI ArgentBox;
    public bool ToUpdate = false;
    private int Currency;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        ToUpdate = false;
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            Currency = gameManager.Coins;
        }
        ArgentBox.text = Currency.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Currency = GameManager.Instance.Coins;
            ArgentBox.text = Currency.ToString();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                {
                    GameObject clickedObject = hit.collider.gameObject;

                    
                    if (clickedObject.name == "Square (1)" && Currency >= 60)
                    {
                        WhichBox = "Plante1";
                        RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        GameManager.Instance.Coins -= 60;
                        Currency = GameManager.Instance.Coins;
                        ToUpdate = true;
                        gameObject.SetActive(false);

                    }
                    else if (clickedObject.name == "Square (2)" && Currency >= 40)
                    {
                        WhichBox = "Plante2";
                        RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        GameManager.Instance.Coins -= 40;
                        Currency = GameManager.Instance.Coins;
                        ToUpdate = true;
                        gameObject.SetActive(false);
                    }
                    else if (clickedObject.name == "Square (3)" && Currency >= 80)
                    {
                        WhichBox = "Plante3";
                        RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        GameManager.Instance.Coins -= 80;
                        Currency = GameManager.Instance.Coins;
                        ToUpdate = true;
                        gameObject.SetActive(false);
                    }
                    else if (clickedObject.name == "Square (4)" && Currency >= 70)
                    {
                        WhichBox = "Plante4";
                        RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        GameManager.Instance.Coins -= 70;
                        Currency = GameManager.Instance.Coins;
                        ToUpdate = true;
                        gameObject.SetActive(false);
                    }
                    else if (clickedObject.name == "Square (5)" && Currency >= 30)
                    {
                        WhichBox = "Plante5";
                        RemoveBox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        GameManager.Instance.Coins -= 30;
                        Currency = GameManager.Instance.Coins;
                        ToUpdate = true;
                        gameObject.SetActive(false);
                    }
                }

        }
    }
}
