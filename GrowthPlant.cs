using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPlant : MonoBehaviour
{
    public Canvas ChoosingScreen;
    public GameObject WillReset;
    private GameObject lastPlantAdul;
    private string PreviousPlant;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VendreScript vendreScript = WillReset.GetComponent<VendreScript>();
        bool needtoreset = vendreScript.Reset;
        SelectPlant selectPlant = ChoosingScreen.GetComponent<SelectPlant>();
        string theplant = selectPlant.WhichBox;

        Dictionary<string, Vector3> plantes = new Dictionary<string, Vector3>();

        plantes.Add("Default", new Vector3(16.46f, 1.94f, 0));
        plantes.Add("Plante1Petite", new Vector3(-0.05f, -1.42f, 0f));
        plantes.Add("Plante2Petite", new Vector3(-0.0204f, -1.63f, 0f));
        plantes.Add("Plante3Petite", new Vector3(-0.05f, -1.89f, 0f));
        plantes.Add("Plante4Petite", new Vector3(0.07f, -1.61f, 0f));
        plantes.Add("Plante5Petite", new Vector3(0.03f, -1.9f, 0f));
        plantes.Add("Plante1Moyenne", new Vector3(0.17f, -1.16f, 0f));
        plantes.Add("Plante2Moyenne", new Vector3(-0.35f, -0.9f, 0f));
        plantes.Add("Plante3Moyenne", new Vector3(-0.04f, -1.08f, 0f));
        plantes.Add("Plante4Moyenne", new Vector3(-0.23f, -1.41f, 0f));
        plantes.Add("Plante5Moyenne", new Vector3(0.02f, -1.5f, 0f));
        plantes.Add("Plante1Adulte", new Vector3(0.12f, -0.48f, 0f));
        plantes.Add("Plante2Adulte", new Vector3(-0.04f, -0.51f, 0f));
        plantes.Add("Plante3Adulte", new Vector3(0.12f, -0.73f, 0f));
        plantes.Add("Plante4Adulte", new Vector3(0.12f, -0.47f, 0f));
        plantes.Add("Plante5Adulte", new Vector3(0.06f, -0.92f, 0f));

        Progressiongenerale progressiongenerale = gameObject.GetComponent<Progressiongenerale>();
        int ActualProgress = progressiongenerale.CurrentProgress;


        if (needtoreset)
        {
            if (lastPlantAdul != null)
            {
                lastPlantAdul.transform.position = plantes["Default"];
                lastPlantAdul = null;
            }
        }

        if (theplant != null && ActualProgress == 0)
        {

            if (PreviousPlant == theplant)
            {
                GameObject PlantStart = GameObject.Find(theplant + "Petite");
                if (PlantStart != null)
                {
                    PlantStart.transform.position = plantes[theplant + "Petite"];
                }
            }
            else
            {
                GameObject PlantStart1 = GameObject.Find(PreviousPlant + "Petite");
                if (PlantStart1 != null)
                {
                    PlantStart1.transform.position = plantes["Default"];
                }
                GameObject PlantStart = GameObject.Find(theplant + "Petite");
                if (PlantStart != null)
                {
                    PlantStart.transform.position = plantes[theplant + "Petite"];
                }
            }
        }

        if ( ActualProgress == 50  && ActualProgress != 100) 
        {
            GameObject PlantStart = GameObject.Find(theplant + "Petite");
            if (PlantStart != null)
            {
                PlantStart.transform.position = plantes["Default"];
                PreviousPlant = theplant;
            }
            GameObject PlantMoy = GameObject.Find(theplant + "Moyenne");
            if (PlantMoy != null)
            {
                PlantMoy.transform.position = plantes[theplant + "Moyenne"];
            }
        }
        if (ActualProgress == 100)
        {
            GameObject PlantStart = GameObject.Find(theplant + "Moyenne");
            if (PlantStart != null)
            {
                PlantStart.transform.position = plantes["Default"];
            }
            GameObject PlantAdul = GameObject.Find(theplant + "Adulte");
            lastPlantAdul = PlantAdul.gameObject;
            if (PlantAdul != null)
            {
                PlantAdul.transform.position = plantes[theplant + "Adulte"];
            }
        }
    }
}
