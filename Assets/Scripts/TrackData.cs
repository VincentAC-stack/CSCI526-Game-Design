
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class TrackData: MonoBehaviour
{
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdkW4EOt3GEJNMO_oLjj24GmgM38inU6tfZ9DDhJ36f-nDA3w/formResponse";
    string _gameResult = "RRRR";
    
    public void Send() 
    {
        StartCoroutine(Post(_gameResult));
    }

    private IEnumerator Post(string _gameResult)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm(); 
        form.AddField("entry.617275958", _gameResult); 
        // Send responses and verify result
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
        // using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) 
        // {
        //     yield return www.SendWebRequest();
        //     if (www.result != UnityWebRequest.Result.Success) {
        //         Debug.Log(www.error); }
        //     else{
        //         Debug.Log("Form upload complete!");} 
        // }
    }
}

