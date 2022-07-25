using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public class User : MonoBehaviour
{
    static string url = "http://localhost:8080/api/v1/registration";

    public Text usernameText;
    public Text emailText;
    public Text passwordText;

    public string id = "";
    public string username = "";
    public string email = "";
    public int coin = 0;

    public User(string id, string username, string email, string coin)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.coin = int.Parse(coin);
    }

    public string toString()
    {
        return "id: " + id + " username: " + username + " email: " + email + " coin: " + coin;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetUser()
    {
        string email = emailText.text;
        string password = passwordText.text;
        
        if (email == "" || password == "")
        {
            Debug.Log("Lütfen boş alan bırakmayınız");
        }
        else
        {
            if (emailValidation(email))
            {
                StartCoroutine(GetUserCoroutine(email, password));
            }
            else
            {
                Debug.Log("Lütfen geçerli bir email adresi giriniz");
            }
        }
    }

    IEnumerator GetUserCoroutine(string email, string password)
    {
        UnityWebRequest www = UnityWebRequest.Get(url + "?email=" + email + "&password=" + password);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            printError(www.downloadHandler.text);
        }
        else
        {
            string userStr = www.downloadHandler.text;
            string[] userStrSplit = userStr.Split('é');
            string username = userStrSplit[0];
            email = userStrSplit[1];
            string id = userStrSplit[2];
            string coin = userStrSplit[3];
            User user = new User(id, username, email, coin);
            Debug.Log("user: " + user.toString());
        }
    }

    public void PutUser()
    {
        string username = usernameText.text;
        string email = emailText.text;
        string password = passwordText.text;
        if (username == "" || email == "" || password == "")
        {
            Debug.Log("Lütfen boş alan bırakmayınız");
        }
        else
        {
            if (emailValidation(email))
            {
                string userData = username + "é" + email + "é" + password;
                StartCoroutine(PutUserCoroutine(userData));
            }
            else
            {
                Debug.Log("Lütfen geçerli bir email adresi giriniz");
            }
        }
        
    }

    IEnumerator PutUserCoroutine(string userData)
    {
        UnityWebRequest www = UnityWebRequest.Put(url, userData);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            printError(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("Başarılı bir şekilde kullanıcı kayıt edildi");
        }
    }

    void printError(string text) {
        Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        Debug.Log("message: " + json["message"]);
        Debug.Log("status: " + json["status"]);
    }

    bool emailValidation(string email) {
        string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        return Regex.IsMatch(email, pattern);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadAsyncScene("Kaydol"));
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(LoadAsyncScene("Giris"));
        }
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        // This is a coroutine
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
