using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarProgressionSoleil : MonoBehaviour
{
    public Slider barprog;
    public GameObject Sun;
    public GameObject BarAll;
    public GameObject Progress;
    public GameObject WillReset;
    private bool Second = false;
    public bool HasFinished = false;
    private float accumulatedTime = 0f;
    private int Multiplier;
    // Start is called before the first frame update
    void Start()
    {
        barprog.gameObject.SetActive(false);
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            Multiplier = gameManager.Soleil;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VendreScript vendreScript = WillReset.GetComponent<VendreScript>();
        bool needtoreset = vendreScript.Reset;
        DragObject dragObject = Sun.GetComponent<DragObject>();
        bool CheckSun = dragObject.HasSun;
        Progressiongenerale progressiongenerale = Progress.GetComponent<Progressiongenerale>();
        int ActualProgress = progressiongenerale.CurrentProgress;

        if (needtoreset)
        {
            ResetSlider();
        }

        if (CheckSun)
        {
            BarAll.GetComponent<SpriteRenderer>().enabled = true;
            barprog.gameObject.SetActive(true);
        }
        if (!CheckSun)
        {
            BarAll.GetComponent<SpriteRenderer>().enabled = false;
            barprog.gameObject.SetActive(false);
        }

        if (ActualProgress == 50 && Second == false)
        {
            ResetSlider();
            Second = true;
        }

    }

    void OnMouseOver()
    {
        DragObject dragObject = Sun.GetComponent<DragObject>();
        bool CheckSun = dragObject.HasSun;

        if (CheckSun)
        {
            accumulatedTime += Time.deltaTime;

            if (!HasFinished)
            {
                float normalizedValue = Mathf.Clamp01((accumulatedTime * (10 * Multiplier)) / 100f);
                barprog.value = normalizedValue * barprog.maxValue;

                if (normalizedValue == 1f)
                {
                    HasFinished = true;
                }
            }
        }
    }
    void ResetSlider()
    {
        barprog.value = 0;
        HasFinished = false;
        Second = false;
        accumulatedTime = 0f;
        Multiplier = GameManager.Instance.Soleil;
    }
}