using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class PickupPulse : MonoBehaviour
{
    Material material;
    int sign = -1;
    [SerializeField] bool shouldPulse = true;
    List<string> coloursToPulse = new();

    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        StartCoroutine(ColourPulse());
        StartCoroutine(AlphaPulse());
    }

    IEnumerator ColourPulse()
    {
        while (shouldPulse)
        {
            Color color = material.color;
            switch (color)
            {
                case Color red when TransitionCheck(color.r) && PulseCheck("Red"):
                    material.color = new(color.r + (Time.deltaTime*sign), color.g, color.b, color.a);
                    break;
                case Color green when TransitionCheck(color.g) && PulseCheck("Green"):
                    material.color = new(color.r, color.g + (Time.deltaTime*sign), color.b, color.a);
                    break;
                case Color blue when TransitionCheck(color.b) && PulseCheck("Blue"):
                    material.color = new(color.r, color.g, color.b + (Time.deltaTime*sign), color.a);
                    break;
                default:
                    sign = -sign;
                    if (sign > 0) RandomiseColoursToPulse();
                    break;
            }
            yield return new WaitForEndOfFrame();
        }

        bool TransitionCheck(float colour) // checks if it's reached its desired colour state, e.g: 100% red, 0% red, etc.
        {
            if (sign < 0 && colour > 0 || sign > 0 && colour < 1) return true;
            return false;
        }

        bool PulseCheck(string colour) // checks if it's even meant to pulse the colour in the first place
        {
            if (coloursToPulse.Contains(colour)) return true;
            return false;
        }

        void RandomiseColoursToPulse()
        {
            coloursToPulse.Clear();
            int rand = Random.Range(0, 2);
            if (rand == 1) coloursToPulse.Add("Red");
            rand = Random.Range(0, 2);
            if (rand == 1) coloursToPulse.Add("Green");
            rand = Random.Range(0, 2);
            if (rand == 1 && !(coloursToPulse.Count == 2)) coloursToPulse.Add("Blue");
        }
    }

    IEnumerator AlphaPulse()
    {
        while (shouldPulse)
        {
            if (sign > 0 && material.color.a < 1 || sign < 0 && material.color.a > 0)
            {
                material.color = new(material.color.r, material.color.g, material.color.b, material.color.a + (0.25f*Time.deltaTime*sign));
                if (material.color.a > 1) material.color = new(material.color.r, material.color.g, material.color.b, 1);
                else if (material.color.a < 0) material.color = new(material.color.r, material.color.g, material.color.b, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
