using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextWriter : MonoBehaviour
{
    private string textToWrite;
    [SerializeField]
    private float timeBetweenLetters;
    [SerializeField]
    private bool isWriting=false;
    [SerializeField]
    private bool stopWrite = false;
    TMP_Text inputText;
    IEnumerator cortuine;
    
    void Awake()
    {
        InputText = GetComponent<TMP_Text>();
    }

    //Start writing on specific place
    public void StartWriter(TMP_Text tmp, string textToWrite)
    {
        stopWrite = false;
        this.textToWrite = textToWrite;
        InputText = tmp;
        CreateCorutine();
    }
    //Stop writing
    public void StopWriter()
    {
        stopWrite = true;
        InputText.text = string.Empty;
    }

    private void CreateCorutine()
    {
        IsWriting = true;
        cortuine = Print(timeBetweenLetters, textToWrite);
        StartCoroutine(cortuine);
    }
    private void StopCorutine()
    {
        IsWriting = false;
    }
    //Corutine method for pass through string
    private IEnumerator Print(float timeBetweenLetters, string textToWrite)
    {
        int iteration=0;
        
        while (iteration!= textToWrite.Length && !stopWrite)
        {
            WriteLetter(textToWrite[iteration], inputText);
            iteration++;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        StopCorutine();
    }

    private void WriteLetter(char letter, TMP_Text inputText)
    {
        InputText.text += letter;
    }

    public void SetTime(float time)
    {
        timeBetweenLetters = time;
    }
    public TMP_Text InputText
    {
        get { return inputText; }
        set { inputText = value; }
    }

    public bool IsWriting { get => isWriting; set => isWriting = value; }
}