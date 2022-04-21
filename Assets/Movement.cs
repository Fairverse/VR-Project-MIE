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
        //var language = new Windows.Globalization.Language("tr");
        //var recognizer = new SpeechRecognizer(language);

        

        //playerAnimator = player.GetComponent<Animator>();   
        actions.Add("marsh", Forward);
        actions.Add("dön", Back);
        actions.Add("saw", Right);
        actions.Add("sol", Left);

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
            StartCoroutine(MoveBack());
        }

        /*if (Input.GetKeyUp(KeyCode.A))
        {
            rotation = Input.GetAxis("Horizontal") * turnSpeed;
            player.Rotate(transform.up, -90);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rotation = Input.GetAxis("Horizontal") * turnSpeed;
            player.Rotate(transform.up, 90);
        }*/
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
}
