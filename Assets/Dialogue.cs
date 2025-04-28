using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textCompoment;
    public string[] lines;
    public float textSpeed;


    private int index;

    void Start()
    {
        textCompoment.text = string.Empty;
        startdialogue();
    }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (textCompoment.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textCompoment.text = lines[index];
            }

        }
    }

    void startdialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            textCompoment.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textCompoment.text = string.Empty;
            StartCoroutine(Typeline());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}

