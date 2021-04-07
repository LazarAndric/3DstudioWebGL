using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextWriter : MonoBehaviour
{
    [Header("Controls")]
    [Header("J: Add text")]
    [Header("K: Start writing")]
    [Header("L: Stop writing")]
    [SerializeField]
    private bool switchWriter = false;
    private Queue<string> textQueue = new Queue<string>();
    [SerializeField]
    private float timeBetweenLetters;
    [TextArea]
    [SerializeField]
    private string text;
    private int idOfText=0;
    private bool isTexting=false;
    TMP_Text inputText;
    IEnumerator cortuine;
    
    void Awake()
    {
        inputText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddTextToWrite(text);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartWriter();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StopWriter();
        }
        if (switchWriter && !isTexting && textQueue.Count>0)
        {
            CreateCorutine();
        }
    }
    //Method for add text into queue
    public void AddTextToWrite(string textToWrite)
    {
        textQueue.Enqueue(textToWrite);
    }

    //Start writing
    public void StartWriter()
    {
        switchWriter = true;
    }
    //Stop writing
    public void StopWriter()
    {
        switchWriter = false;
        inputText.text = string.Empty;
    }

    private void CreateCorutine()
    {
        isTexting = true;
        cortuine = PrintWord(timeBetweenLetters,textQueue.Dequeue()+"\n");
        StartCoroutine(cortuine);
    }
    //Corutine method for pass through string
    private IEnumerator PrintWord(float timeBetweenLetters, string textToWrite)
    {
        int iteration=0;
        
        while (iteration!= textToWrite.Length && switchWriter)
        {
            WriteLetter(textToWrite[iteration], inputText);
            iteration++;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        isTexting = false;
    }

    private void WriteLetter(char letter, TMP_Text inputText)
    {
        inputText.text += letter;
    }

    public void SetTime(float time)
    {
        timeBetweenLetters = time;
    }
}