using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // sending data to google form
    public static string URL = "https://docs.google.com/forms/d/e/1FAIpQLSd-S6YVYOZnN_6exc5vZ5VZo5YNYqJp_lvhJsBtB9ELpxqVrQ/formResponse";
    public static long SessionID;
    public static string LevelName;
    public  static bool GameResult;
    public static int FlipCounts = 0;
    public static int LevelDeaths = 0;
}
