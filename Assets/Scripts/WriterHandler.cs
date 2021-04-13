using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WriterHandler : MonoBehaviour
{
    private List<string> texts = new List<string>();
    private List<TextWriter> writers = new List<TextWriter>();
    private bool stopWriter = false;
    IEnumerator corutine;

    private void Start()
    {
        var list=GetComponentsInChildren<TextWriter>();
        foreach (var item in list)
            writers.Add(item);
    }
    public void StartWriter(List<string> texts)
    {
        stopWriter = false;
        ImportTexts(texts);
        corutine = Writing(writers[0], 0);
        StartCoroutine(corutine);
    }
    public void ClearWriter()
    {
        stopWriter = true;
        foreach (var item in writers)
        {
            item.StopWriter();
        }
    }
    private void ImportTexts(List<string> texts)
    {
        foreach (var item in texts)
        {
            this.texts.Add(item);
        }
    }
    private IEnumerator Writing(TextWriter lastWriter, int iteration)
    {
        while(lastWriter.IsWriting)
        {
            yield return new WaitForSeconds(1f);
        }
        if (!stopWriter)
        {
            StartWriter(ref lastWriter, ref iteration);
            if (iteration < writers.Count)
            {
                corutine = Writing(lastWriter, iteration);
                StartCoroutine(corutine);
            }
        }
    }
    private void StartWriter(ref TextWriter lastWriter, ref int i)
    {
        writers[i].StartWriter(writers[i].InputText, texts[i]);
        lastWriter = writers[i];
        i++;
    }

}
