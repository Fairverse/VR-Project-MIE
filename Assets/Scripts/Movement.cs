using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Movement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    
    private bool _isForward = true;

    private Quaternion _targetRot = Quaternion.identity;

    [SerializeField]
    private float _rotateSpeed = 5f;

    public bool isMovingForward;
    public bool isMovingBack;

    public float turnSpeed;
    float rotation;

    public int movementSpeed;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        //var language = new Windows.Globalization.Language("tr"); //gerekli de�il
        //var recognizer = new SpeechRecognizer(language); //gerekli de�il

        

        //playerAnimator = player.GetComponent<Animator>();   
        actions.Add("marsh", Forward);
        actions.Add("d�n", Back);
        actions.Add("saw", Right);
        actions.Add("sol", Left);
        actions.Add("hey", Wave);
        actions.Add("menu", GameManager.instance.OpenMenuPanel);
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.coinCount = PlayerPrefs.GetInt("coinCount");

        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, _targetRot, _rotateSpeed * Time.deltaTime);

        if (isMovingForward)
        {
            Move(movementSpeed);
        }

        if (isMovingBack)
        {
            Move(-movementSpeed);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            StartCoroutine(MoveForward());
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Back();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Left();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Right();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Wave();
        }

        if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            Salsa();

            GameManager.instance.vcam2.Priority = 11;
        }
    }
    
    public void Move(float movementSpeed)
    {
        player.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    public IEnumerator MoveForward()
    {
        isMovingForward = true;
        player.GetComponent<Animator>().SetBool("Walking", true);

        yield return new WaitForSeconds(2);

        player.GetComponent<Animator>().SetBool("Walking", false);
        isMovingForward = false;
    }

    public IEnumerator MoveBack()
    {
        isMovingBack = true;
        player.GetComponent<Animator>().SetBool("WalkingBack", true);

        yield return new WaitForSeconds(2);

        player.GetComponent<Animator>().SetBool("WalkingBack", false);
        isMovingBack = false;
    }

    public void Forward()
    {
        StartCoroutine(MoveForward());
    }

    public void Back()
    {
        _targetRot *= Quaternion.AngleAxis(180, Vector3.up);
    }

    public void Right()
    {
       // _isForward = !_isForward;

        _targetRot *= Quaternion.AngleAxis(90, Vector3.up);
    }
    public void Left()
    {
       // _isForward = !_isForward;

        _targetRot *= Quaternion.AngleAxis(-90, Vector3.up);
    }

    public void Wave()
    {
        player.GetComponent<Animator>().SetTrigger("Waving");

        IncreaseCoin();
    }

    public void Salsa()
    {
        player.GetComponent<Animator>().SetTrigger("Salsa");

        IncreaseCoin();
    }

    public void IncreaseCoin()
    {
        GameManager.instance.coinCount++;

        PlayerPrefs.SetInt("coinCount", GameManager.instance.coinCount);
    }

}
