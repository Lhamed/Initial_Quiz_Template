
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
/// <summary>
/// Quiz data provider.
/// Text Asset ->  JSON -> [QuitSheet] Class Instance 
/// </summary>
public class QuizDataProvider
{
    readonly string QuizDataPath = "QuizData";

    readonly string MainQuizDataSubPath = "Main";

    Dictionary<string, QuizSheet> quizSheetDictionary = new Dictionary<string, QuizSheet>();

    public Dictionary<string, QuizSheet> QuizSheetDictionary
    {
        get
        {
            if (quizSheetDictionary == null) quizSheetDictionary = CreateQuizDictionary(MainQuizDataSubPath);
            return quizSheetDictionary;
        }
    }

    public QuizSheet[] GetNotCompletedSheets(string[] completedSheetIds)
    {
        var quizSheetTemp = CreateQuizDictionary(MainQuizDataSubPath);

        for (int i = 0; i < completedSheetIds.Length; i++)
        {
            string id = completedSheetIds[i];
            if (quizSheetTemp.ContainsKey(id)) quizSheetTemp.Remove(id);
        }
        var sheetArray = quizSheetTemp.Select(z => z.Value).ToArray();

        return sheetArray;
    }

    Dictionary<string, QuizSheet> CreateQuizDictionary(string target)
    {
        var quizSheetDictionaryTemp = new Dictionary<string, QuizSheet>();
        string JsonDataTemp = LoadJsonStringFromResourcesFolder(QuizDataPath, target);
        QuizSheet[] sheetArray = JsonUtility.FromJson<QuizSheet[]>(JsonDataTemp);
        int sheetIndex = 0;
        foreach (var sheet in sheetArray)
        {

            if (sheet.Id == null) throw new Exception("IdtFoundException: Index[" + sheetIndex + "]");
            quizSheetDictionaryTemp.Add(sheet.Id, sheet);
            sheetIndex++;
        }
        return quizSheetDictionaryTemp;
    }


    //this method can be extracted to some otehr class.. Like public static "JsonDataManager"..? 
    string LoadJsonStringFromResourcesFolder(string pathRelativeToResouresFolder, string target)
    {
        string targetPath = Path.Combine(pathRelativeToResouresFolder, target);
        Debug.Log("Load Text Asset At : " + targetPath);
        TextAsset textAssetTemp = Resources.Load<TextAsset>(targetPath);

        if (textAssetTemp == null) throw new Exception("AssetNotFoundException: " + targetPath);

        string resultJsonString = textAssetTemp.text;
        return resultJsonString;
    }

}

// ! : Resources.Load <- can be used Also in On Non-Monobehaviour Subclass. ( 20190215 )
