using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenarioToDict
{
    public Dictionary<int, string> GetScenarioDictionary()
    {
        Dictionary<int, string> scenarioDict = new Dictionary<int, string>();
        TextAsset csvFile = Resources.Load<TextAsset>("ScenarioSample");

        if (csvFile != null)
        {
            StringReader reader = new StringReader(csvFile.text);
            bool isFirstLine = true;
            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue; // スキップヘッダー
                }

                string[] elements = line.Split(',');
                if (elements.Length >= 2 && int.TryParse(elements[0], out int id))
                {
                    string message = elements[1];
                    scenarioDict.Add(id, message);
                }
            }
        }
        else
        {
            Debug.LogError("CSV file not found");
        }

        return scenarioDict;
    }
}
