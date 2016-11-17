using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public static class MyScoreManager {
	public const int numberOfLevels=11;
    public static int totalScore { get; set; }
 //   public static int[] scoreByLevel { get; set; }
    public static int lastUnlockedLevel { get; set; }

	public static void initializing(){
        if (PlayerPrefs.GetString("firstTime").Equals("no"))
        {   loadALL();        }
        else
        { totalScore = 0; lastUnlockedLevel = 0; saveAll();    }

    }
    private static void loadALL()
    {
        //load total Score
        totalScore = PlayerPrefs.GetInt("totalScore");
        lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel");
    }
    public static void saveAll()
    {
        //load total Score
        PlayerPrefs.SetString("firstTime", "no");
        PlayerPrefs.SetInt("totalScore", totalScore);
       PlayerPrefs.SetInt("lastUnlockedLevel", lastUnlockedLevel);
    }


}
