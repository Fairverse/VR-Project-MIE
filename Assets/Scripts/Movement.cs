using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Movement : MonoBehaviour
{
    public int danceNum = 0;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    
    private bool _isForward = true;

    private Quaternion _targetRot = Quaternion.identity;

    [SerializeField]
    private float _rotateSpeed = 5f;

    public bool canRun;
    public bool isDance;
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
        //var language = new Windows.Globalization.Language("tr"); //gerekli de�il
        //var recognizer = new SpeechRecognizer(language); //gerekli de�il

        

        //playerAnimator = player.GetComponent<Animator>();   
        actions.Add("marsh", Forward);
        actions.Add("done", Back);
        actions.Add("saw", Right);
        actions.Add("sol", Left);
        actions.Add("hey", Wave);
        actions.Add("menu", GameManager.instance.OpenMenuPanel);
        actions.Add("party", Dance);
        actions.Add("kosh", Run);
        
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
            if(!isMovingForward && !isDance)
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
            if (!isDance && !isMovingForward)
                Dance();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!isMovingForward && !isDance)
                StartCoroutine(RunForward());
        }

        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Harmandali") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gangnam") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Kolbasti"))
        {
            GameManager.instance.vcam2.Priority = 11;
        }

        else if (GameManager.instance.vcam2.Priority != 9)
        {
            GameManager.instance.vcam2.Priority = 9;
            GameManager.instance.AudioManager.GetComponent<AudioSource>().Stop();
            isDance = false;
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

    public IEnumerator RunForward()
    {
        isMovingForward = true;
        player.GetComponent<Animator>().SetBool("Running", true);
        movementSpeed = 5;

        yield return new WaitForSeconds(2);

        player.GetComponent<Animator>().SetBool("Running", false);
        movementSpeed = 1;

        isMovingForward = false;
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
        _targetRot *= Quaternion.AngleAxis(45, Vector3.up);
    }
    public void Left()
    {
        _targetRot *= Quaternion.AngleAxis(-45, Vector3.up);
    }

    public void Run()
    {
        StartCoroutine(RunForward());
    }

    public void Wave()
    {
        player.GetComponent<Animator>().SetTrigger("Waving");

        GameManager.instance.IncreaseCoin();
    }

    public void Dance()
    {
        isDance = true;
        //int danceNum = UnityEngine.Random.Range(0, 3);
        //int danceNum = 0;

        if (danceNum == 0)
        {
            player.GetComponent<Animator>().SetTrigger("Kolbasti");

            GameManager.instance.AudioManager.GetComponent<AudioSource>().clip = GameManager.instance.AudioManager.kolbasti;
            GameManager.instance.AudioManager.GetComponent<AudioSource>().Play();
            danceNum++;
        }
        
        else if (danceNum == 1)
        {
            player.GetComponent<Animator>().SetTrigger("Gangnam");

            GameManager.instance.AudioManager.GetComponent<AudioSource>().clip = GameManager.instance.AudioManager.gangnam;
            GameManager.instance.AudioManager.GetComponent<AudioSource>().Play();
            danceNum++;
        }

        else if(danceNum == 2)
        {
            player.GetComponent<Animator>().SetTrigger("Harmandali");

            GameManager.instance.AudioManager.GetComponent<AudioSource>().clip = GameManager.instance.AudioManager.harmandali;
            GameManager.instance.AudioManager.GetComponent<AudioSource>().Play();
            danceNum = 0;
        }

        GameManager.instance.IncreaseCoin();
    }
}
