﻿using UnityEngine;
using System.Collections;
using C5;
using System;
using System.Linq;
using LitJson;

public class Level : MonoBehaviour{
    /*
	 * A puzzle level. After giving a set of inputs to a
	 * set of LogicObjects, it expects a set of outputs
	 * and compares whether the set of outputs is correct.
	 */
    private String levelName;
    private String creator;
    private int levelPar;
    private int minScore;
    private ArrayList<Module> gates;
    private ArrayList<bool> input;
    private ArrayList<bool> output;
    //for testing only
    void Start()
    {
        loadLevel("level4-Mack");
        saveLevel();
        saveAsNewLevel("mackLevel", "MackHeller");
    }
    public void loadLevel(string levelName)
    {
        this.levelName = levelName;
        setLevelValues(LevelReader.loadNewLevel(levelName));
    }
    /*
     * save level with level's existing file name
     * */
    public void saveLevel()
    {
        LevelWriter.saveAsNewLevel(createLevelname(this.levelName, this.creator), this);
    }
    /*
     * save level with a new file name
     * */
    public void saveAsNewLevel(string levelName, string creator) 
    {
        String filename = createLevelname(levelName, creator);
        if (LevelReader.getAllLevelNames().Contains(filename))
            throw new ArgumentException("Cannot create a new File, a level with the name: "+ levelName +
                " created by: "+ creator+" already exists");
        else
            LevelWriter.saveAsNewLevel(filename, this);
    }
    public void setLevelValues(JsonData jsonData)
    {
        this.levelName = LevelReader.getLevelName(jsonData);
        this.levelPar = LevelReader.getLevelPar(jsonData);
        this.minScore = LevelReader.getMinScore(jsonData);
        this.gates = LevelReader.getGates(jsonData);
        this.input = LevelReader.getLevelInput(jsonData);
        this.output = LevelReader.getLevelOutput(jsonData);
        this.creator = LevelReader.getCreator(jsonData);
    }
    /*
     * Checks if gate exists in the current level
     * name = name of a valid gate
     * */
    public bool hasGate(String name)
    {
        for (int i = 0; i < gates.Count; i++)
        {
            if (gates[i].getName().Equals(name))
            {
                return true;
            }
        }
        return false;
    }
    /*
     * get the max amount of a certain gate the level allows. If there is no limit it returns the MaxValue.
     * Throws Exception if gate does not exist
     * name = name of a valid gate
     * */
    public int getGateAmount(String name)
    {
        for (int i = 0; i < gates.Count; i++)
        {
            if (gates[i].getName().Equals(name))
            {
                return gates[i].getAmount();
            }
        }
        throw new System.
            Exception("Tried to request gate that does not exist in the current level");
    }
    private String createLevelname(String level, String creator) { return level + "-" + creator; }
    /* getter methods
     */
    public ArrayList<Module> getGates() { return gates; }
    public ArrayList<bool> getLevelInput(){return input;}
    public ArrayList<bool> getLevelOutput(){return output;}
    public String getLevelName() { return levelName;}
    public String getCreator() { return creator; }
    public int getLevelPar() { return levelPar; }
    public int getMinScore() { return minScore; }
    /* setter methods
     */
    public void setGates(ArrayList<Module> gates) { this.gates= gates; }
    public void setLevelInput(ArrayList<bool> input) { this.input = input; }
    public void setLevelOutput(ArrayList<bool> output) { this.output = output; }
    public void setLevelName(String levelName) { this.levelName = levelName; }
    public void setLevelPar(int levelPar) { this.levelPar = levelPar; }
    public void setMinScore(int minScore) { this.minScore = minScore; }
    public void setCreator(String creator) { this.creator = creator; }
}