using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progressiongenerale : MonoBehaviour
{
    public Slider Barre;
    public GameObject Plante;
    public TextMeshProUGUI textMeshProUGUI;
    public int CurrentProgress = 0;
    private bool hasupdatedsun = false;
    private bool hasupdatedeau = false;
    private bool hasupdatedengrais = false;
    private bool hasupdatedsun1 = false;
    private bool hasupdatedeau2 = false;
    private bool hasupdatedengrais3 = false;
    private bool isUpdatingBarre = false;
    private bool Reach = false;
    public GameObject WillReset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        VendreScript vendreScript = WillReset.GetComponent<VendreScript>();
        bool needtoreset = vendreScript.Reset;
        BarProgressionSoleil barProgressionSoleil = Plante.GetComponent<BarProgressionSoleil>();
        bool HasFinishedSun = barProgressionSoleil.HasFinished;
        BarProgressionEau barProgressionEau = Plante.GetComponent<BarProgressionEau>();
        bool HasFinishedEau = barProgressionEau.HasFinished;
        BarProgressionEngrais barProgressionEngrais = Plante.GetComponent<BarProgressionEngrais>();
        bool HasFinishedEngrais = barProgressionEngrais.HasFinished;

        if (needtoreset && Reach == true)
        {
            Barre.value = 0;
            CurrentProgress = 0;
            textMeshProUGUI.text = "0%";
            hasupdatedeau = false;
            hasupdatedengrais = false;
            hasupdatedeau2 = false;
            hasupdatedengrais3 = false;
            hasupdatedsun = false;
            hasupdatedsun1 = false;
            Reach = false;
        }


        if (HasFinishedSun && hasupdatedsun == false && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedsun = true;
        }
        if (HasFinishedEau && hasupdatedeau == false && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedeau = true;
        }
        if (HasFinishedEngrais && hasupdatedengrais == false && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedengrais = true;
        }

        if (HasFinishedSun && hasupdatedsun1 == false && Barre.value >= 0.5 && Barre.value != 1 && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedsun1 = true;
        }
        if (HasFinishedEau && hasupdatedeau2 == false && Barre.value >= 0.5 && Barre.value != 1 && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedeau2 = true;
        }
        if (HasFinishedEngrais && hasupdatedengrais3 == false && Barre.value >= 0.5 && Barre.value != 1 && !isUpdatingBarre)
        {
            StartCoroutine(SmoothValueChange(Barre.value + (1f / 2f) * (1f / 3f)));
            hasupdatedengrais3 = true;
        }

        if (Barre.value == 1)
        {
            Reach = true;
        }

    }
    IEnumerator SmoothValueChange(float targetValue)
    {
        float elapsedTime = 0f;
        float startValue = Barre.value;
        textMeshProUGUI.text = ((int)(targetValue * 100)).ToString() + "%";
        CurrentProgress = (int)(targetValue * 100);

        while (elapsedTime < 1f)
        {
            Barre.value = Mathf.Lerp(startValue, targetValue, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Barre.value = targetValue;
        isUpdatingBarre = false;
        yield return null;
    }
}
