using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL = "https://docs.google.com/forms/d/e/1FAIpQLSd-S6YVYOZnN_6exc5vZ5VZo5YNYqJp_lvhJsBtB9ELpxqVrQ/formResponse";
    
    // Http链接
    private String _sessionID;
    private int _testInt;
    private bool _testBool;
    private float _testFloat;
    
    // 数据 何瑛琪 负责部分
    private int _mechanismSection;
    private int _level;
    private int _attempt;
    private int _complete;
    private int _timeSpent;
    private int _retriesNumber;
    
    // 数据 王思极 & 徐通负责部分
    private int _surviveC1;
    private int _surviveC2;
    private int _surviveC3;
    private int _surviveC4;
    private int _surviveC5;
    private int _timeSpentC1;
    private int _timeSpentC2;
    private int _timeSpentC3;
    private int _timeSpentC4;
    private int _timeSpentC5;
    private int _remainingHealthC1;
    private int _remainingHealthC2;
    private int _remainingHealthC3;
    private int _remainingHealthC4;
    private int _remainingHealthC5;
    private int _jCount;
    private int _jCountC1;
    private int _jCountC2;
    private int _jCountC3;
    private int _jCountC4;
    private int _jCountC5;
    
    // 数据 吴奕宙 负责部分
    private int _losePointsReason;
    
    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Send();
        }
    }

    private void Send()
    {
        StartCoroutine(Post());
    }
    
    // Post
    private IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.694268104", _mechanismSection);
        form.AddField("entry.1179097589", _level);
        form.AddField("entry.1585400280", _sessionID);
        form.AddField("entry.199638597", _attempt);
        form.AddField("entry.188062634", _complete);
        form.AddField("entry.1478498527", _timeSpent);
        form.AddField("entry.820838070", _retriesNumber);
        form.AddField("entry.1450257209", _surviveC1);
        form.AddField("entry.1364728483", _surviveC2);
        form.AddField("entry.231225115", _surviveC3);
        form.AddField("entry.73692411", _surviveC4);
        form.AddField("entry.1754632933", _surviveC5);
        form.AddField("entry.1245109354", _timeSpentC1);
        form.AddField("entry.628811664", _timeSpentC2);
        form.AddField("entry.424709657", _timeSpentC3);
        form.AddField("entry.802975287", _timeSpentC4);
        form.AddField("entry.178535423", _timeSpentC5);
        form.AddField("entry.498993239", _remainingHealthC1);
        form.AddField("entry.927801927", _remainingHealthC2);
        form.AddField("entry.1301255164", _remainingHealthC3);
        form.AddField("entry.529486672", _remainingHealthC4);
        form.AddField("entry.588232958", _remainingHealthC5);
        form.AddField("entry.1530851387", _losePointsReason);
        form.AddField("entry.107226697", _jCount);
        form.AddField("entry.2003297119", _jCountC1);
        form.AddField("entry.1767977406", _jCountC2);
        form.AddField("entry.650173284", _jCountC3);
        form.AddField("entry.975144134", _jCountC4);
        form.AddField("entry.1994227933", _jCountC5);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
