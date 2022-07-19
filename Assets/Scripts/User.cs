using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class User : MonoBehaviour
{
    readonly string url = "http://localhost:8080/api/v1/user1";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetUser()
    {
        StartCoroutine(GetUserCoroutine());
    }

    IEnumerator GetUserCoroutine()
    {
        string mail = "hkc@gmail.com";
        string password = "123456789";
        UnityWebRequest www = UnityWebRequest.Get(url + "?mail=" + mail + "&password=" + password);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("error: " + www.error);
        }
        else
        {
            Debug.Log("user: " + www.downloadHandler.data);
        }
    }

    public void PutUser()
    {
        string username = "Mr. Bülüç";
        string mail = "hkcblc@gmail.com";
        string password = "123456";
        string userData = username + "é" + mail + "é" + password;
        StartCoroutine(PutUserCoroutine(userData));
    }

    IEnumerator PutUserCoroutine(string userData)
    {
        UnityWebRequest www = UnityWebRequest.Put(url, userData);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            string text = www.downloadHandler.text;
            Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            Debug.Log("message: " + json["message"]);
            Debug.Log("status: " + json["status"]);
        }
        else
        {
            Debug.Log("Başarılı bir şekilde kullanıcı kayıt edildi");
        }
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
    }
}
