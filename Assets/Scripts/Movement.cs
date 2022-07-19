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

    #region Singleton
    public static Movement instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //var language = new Windows.Globalization.Language("tr"); //gerekli deðil
        //var recognizer = new SpeechRecognizer(language); //gerekli deðil

        

        //playerAnimator = player.GetComponent<Animator>();   
        actions.Add("marsh", Forward);
        actions.Add("dön", Back);
        actions.Add("saw", Right);
        actions.Add("sol", Left);
        actions.Add("hey", Wave);
        actions.Add("menu", GameManager.instance.OpenMenuPanel);
        actions.Add("dance", Dance);
        
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
            Dance();
            GameManager.instance.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

        }

        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Salsa") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gangnam") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HipHop"))
        {
            GameManager.instance.vcam2.Priority = 11;
        }

        else if (GameManager.instance.vcam2.Priority != 9)
        {
            GameManager.instance.vcam2.Priority = 9;
            GameManager.instance.GetComponent<AudioSource>().Stop();
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
        _targetRot *= Quaternion.AngleAxis(90, Vector3.up);
    }
    public void Left()
    {
        _targetRot *= Quaternion.AngleAxis(-90, Vector3.up);
    }

    public void Wave()
    {
        player.GetComponent<Animator>().SetTrigger("Waving");

        IncreaseCoin();
    }

    public void Dance()
    {
        int danceNum = UnityEngine.Random.Range(0, 3);
        //Debug.Log(danceNum);

        if (danceNum == 0)
        {
            player.GetComponent<Animator>().SetTrigger("Salsa");
        }
        
        if (danceNum == 1)
        {
            player.GetComponent<Animator>().SetTrigger("Gangnam");
        }

        if(danceNum == 2)
        {
            player.GetComponent<Animator>().SetTrigger("HipHop");
        }

        IncreaseCoin();
    }

    public void IncreaseCoin()
    {
        GameManager.instance.coinCount++;

        PlayerPrefs.SetInt("coinCount", GameManager.instance.coinCount);
    }
}
