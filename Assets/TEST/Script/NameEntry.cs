using UnityEngine;
using TMPro;
using System.IO;

public class NameEntry : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int max;//表示できる最大数
    [SerializeField] TextMeshProUGUI[] oldScores;
    [SerializeField] string[] scores;
    [SerializeField] TextMeshProUGUI[] oldNames;
    [SerializeField] string[] names;
    [SerializeField] string score;
    [SerializeField] string userName;
    [SerializeField] 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputField.Select();
        max = oldScores.Length;
        LoadSavedData("score",scores);
        LoadSavedData("name", names);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            text.text = inputField.text;
            if(inputField.text == "")
            {
                text.text = "名無子";
            }
        }
    }
    void LoadSavedData(string fileName, string[] datas)
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".txt";
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                for(int i=0;i<=max;i++)
                {
                    if (datas[i] !=null)
                    {
                        datas[i] = reader.ReadLine();
                    }
                    else
                    {
                        if(fileName == "score")
                        {
                            datas[i] = "00";
                        }
                        else
                        {
                            datas[i] = "名無子";
                        }
                    }
                }
            }
        }
        else
        {
            File.Create(path);
        }
    }
    public void OnClick()
    {
        WriteSaveData();
    }
    void WriteSaveData()
    {
        string nameData = File.ReadAllText(Application.streamingAssetsPath + "/name.txt");
        string scoreData = File.ReadAllText(Application.streamingAssetsPath + "/score.txt");
        nameData = userName + "\r\n" + nameData;
        scoreData = score + "\r\n" + scoreData;
        File.WriteAllText(Application.streamingAssetsPath + "/name.txt", nameData);
        File.WriteAllText(Application.streamingAssetsPath + "/score.txt", scoreData);
    }
}
