using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizSystem
{
    UIHandler uiHandler;

    readonly string InitialDisplayKey  = "Initial_Display_Text", QuestionDisplayKey = "Question_Diplay_Text"
    , HintListDisplayKey = "HintListDisplayText"; 

    public virtual void SetUpUiHandler()
    {
        if(UIHandler.Instance != null) UIHandler.Instance.Destory();
        uiHandler = UIHandler.Instance;


        var InitialDisplayText = GameObject.Find(InitialDisplayKey).gameObject.GetComponent<Text>();
        uiHandler.EnrollUIComponent(InitialDisplayText, InitialDisplayKey);

        var QuestionDiplayText = GameObject.Find(QuestionDisplayKey).gameObject.GetComponent<Text>();
        uiHandler.EnrollUIComponent(QuestionDiplayText, QuestionDisplayKey);

        var HintListDisplayText = GameObject.Find(HintListDisplayKey).gameObject.GetComponent<Text>();
        uiHandler.EnrollUIComponent(HintListDisplayText, HintListDisplayKey);


    }
}


public class EndlessQuizSystem : QuizSystem
{

}

public class ArcadeQuizSystem : QuizSystem
{

}

public class TimeAttackQuizSystem : QuizSystem
{

}