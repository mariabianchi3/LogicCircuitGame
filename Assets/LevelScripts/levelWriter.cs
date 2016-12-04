using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class LevelWriter {

    public static void saveAsNewLevel(string levelName, Level level) {
        writerLevel(Application.dataPath + "/Levels/" + levelName + ".JSON", level);
	}

    private static void writerLevel(string filePath, Level level) {
        StreamWriter sw = null;
        string json = "{\"LevelName\": \"" + level.getLevelName() + "\",\n\"Creator\": \"" + level.getCreator() + 
            "\",\n\"star1\": " + level.getStars()[0] + "\",\n\"star2\": " + level.getStars()[1] + ",\n\"star3\":" + level.getStars()[2];
        //do gates
        ArrayList<LogicModule> gates = level.getGates();
        if (gates.Count > 0)
            json = json + ",\n\"Gates\": [";
        for (int i = 0; i < gates.Count; i++) {
            json = json + "{\"Name\": \"" + gates[i].getName() + "\",\n\"Amount\": " + gates[i].getAmountAllowed() + "},\n";
        }
        if (gates.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do inputs
        ArrayList<Int32> inputs = level.getLevelInput();
        if (inputs.Count > 0)
            json = json + ",\n\"Inputs\": [";
        for (int i = 0; i < inputs.Count; i++) {
            json = json + "{\"Id\": " + inputs[i] + "},\n";
        }
        if (inputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do outputs
        ArrayList<Int32> outputs = level.getLevelOutput();
        if (outputs.Count > 0)
            json = json + ",\n\"Outputs\": [";
        for (int i = 0; i < outputs.Count; i++) {
            json = json + "{\"Id\": " + inputs[i] + "},\n";
        }
        if (outputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";
        json = json + "}";
        try {
            sw = new StreamWriter(filePath);
            sw.WriteLine(json);
        } catch (IOException e) {
            Console.WriteLine(e.Message);
        } finally {
            if (sw != null)
                sw.Dispose();
        }
    }
}
