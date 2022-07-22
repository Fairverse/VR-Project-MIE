using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public class User : MonoBehaviour
{
    readonly string url = "http://localhost:8080/api/v1/registration";

    public Text usernameText;
    public Text emailText;
    public Text passwordText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetUser()
    {
        StartCoroutine(GetUserCoroutine());
        Debug.Log("bu da çalıştı");
    }

    IEnumerator GetUserCoroutine()
    {
        string mail = "hkc@gmail.com";
        string password = "123456789";
        UnityWebRequest www = UnityWebRequest.Get(url + "?mail=" + mail + "&password=" + password);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            printError(www.downloadHandler.text);
        }
        else
        {
            string userStr = www.downloadHandler.text;
            string[] userStrSplit = userStr.Split('é');
            string username = userStrSplit[0];
            mail = userStrSplit[1];
            string id = userStrSplit[2];
            Dictionary<string, string> user = new Dictionary<string, string>();
            user.Add("username", username);
            user.Add("mail", mail);
            user.Add("id", id);
            print("user: " + JsonConvert.SerializeObject(user));
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

        if (www.isNetworkError || www.isHttpError)
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
    void Update(){}
}
