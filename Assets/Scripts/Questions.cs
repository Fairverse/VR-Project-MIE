using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public AudioClip Q1Audio;
    public AudioClip Q2Audio;
    public AudioClip Q3Audio;

    public GameObject questionPanel;

    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;

    public enum AnswerButton { Right, Left};
    public AnswerButton correctAnswer1;
    public AnswerButton correctAnswer2;
    public AnswerButton correctAnswer3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnswerLeftButton()
    {
        if (Q1.activeInHierarchy && correctAnswer1 == AnswerButton.Left)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q1Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }

        if (Q2.activeInHierarchy && correctAnswer2 == AnswerButton.Left)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q2Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }

        if (Q3.activeInHierarchy && correctAnswer3 == AnswerButton.Left)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q3Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }
    }
    
    public void AnswerRightButton()
    {
        if (Q1.activeInHierarchy && correctAnswer1 == AnswerButton.Right)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q1Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }

        if (Q2.activeInHierarchy && correctAnswer2 == AnswerButton.Right)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q2Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }

        if (Q3.activeInHierarchy && correctAnswer3 == AnswerButton.Right)
        {
            Debug.Log("corretto");
            NPCTrigger.instance.questionOrder++;
            NPCTrigger.instance.FinishQuestion();
        }

        else
        {
            GetComponent<AudioSource>().clip = Q3Audio;
            GetComponent<AudioSource>().Play();
            NPCTrigger.instance.FinishQuestion();
            Debug.Log("falso");
        }
    }
}
