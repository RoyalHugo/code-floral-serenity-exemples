using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarProgressionEau : MonoBehaviour
{
    public Slider barprog1;
    public GameObject Water;
    public GameObject BarAll1;
    public GameObject Progress;
    public GameObject WillReset;
    public bool HasFinished = false;
    private bool Second = false;
    private float accumulatedTime1 = 0f;
    private int Multiplier;
    // Start is called before the first frame update
    void Start()
    {
        barprog1.gameObject.SetActive(false);
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            Multiplier = gameManager.Eau;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VendreScript vendreScript = WillReset.GetComponent<VendreScript>();
        bool needtoreset = vendreScript.Reset;
        DragObject dragObject = Water.GetComponent<DragObject>();
        bool CheckWater = dragObject.HasWater;
        Progressiongenerale progressiongenerale = Progress.GetComponent<Progressiongenerale>();
        int ActualProgress = progressiongenerale.CurrentProgress;

        if (needtoreset)
        {
            ResetSlider();
        }
        if (CheckWater)
        {
            BarAll1.GetComponent<SpriteRenderer>().enabled = true;
            barprog1.gameObject.SetActive(true);
        }
        if (!CheckWater)
        {
            BarAll1.GetComponent<SpriteRenderer>().enabled = false;
            barprog1.gameObject.SetActive(false);
        }
        if (ActualProgress == 50 && Second == false)
        {
            ResetSlider();
            Second = true;
        }

    }

    void OnMouseOver()
    {

        DragObject dragObject = Water.GetComponent<DragObject>();
        bool CheckWater = dragObject.HasWater;

        if (CheckWater) 
        {
            accumulatedTime1 += Time.deltaTime;

            if (!HasFinished)
            {
                float normalizedValue = Mathf.Clamp01((accumulatedTime1 * (10 * Multiplier)) / 100f);
                barprog1.value = normalizedValue * barprog1.maxValue;

                if (normalizedValue == 1f)
                {
                    HasFinished = true;
                }
            }
        }

    }

    void ResetSlider()
    {
        barprog1.value = 0;
        HasFinished = false;
        Second = false;
        accumulatedTime1 = 0f;
        Multiplier = GameManager.Instance.Eau;
    }
}
