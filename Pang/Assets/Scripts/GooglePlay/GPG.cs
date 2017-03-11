using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPG : MonoBehaviour
{

    public string leaderboard;

    void Start()
    {
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();


    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            Debug.Log(success);
        });
    }



    public void OnShowLeaderBoard()
    {
        //		Social.ShowLeaderboardUI (); // Show all leaderboard
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard); // Show current (Active) leaderboard
        Debug.Log(leaderboard);
    }

    public void OnShowAchievements()
    {
        ((PlayGamesPlatform)Social.Active).ShowAchievementsUI();
    }

    public void OnAddScoreToLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(100, leaderboard, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Update Score Success");

                }
                else
                {
                    Debug.Log("Update Score Fail");
                }
            });
        }
    }

    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

}