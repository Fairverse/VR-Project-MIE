using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class User : MonoBehaviour
{
    readonly string url = "http://localhost:8080/api/v1/user1";

    public Text username;
    public Text email;
    public Text password;


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
        string username = "hkc";
        string mail = "hkc@gmail.com";
        string password = "123456789";
        string userData = username + "é" + mail + "é" + password;
        StartCoroutine(PutUserCoroutine(userData));

        Debug.Log("çalıştı");
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetUser();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PutUser();
        }

        Debug.Log(username.text);
        Debug.Log(email.text);
        Debug.Log(password.text);
    }

}
