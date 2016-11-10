﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GateAND : Module {
	/*
	 * An many-to-one OR gate.
	 * 
	 * TODO: adjust module to wait on multiple inputs.
	 */

	// Constructor called by the factory method
	public GateAND (int numInputs, IList<LogicObject> outputObjects) {
		inputBoolCount = numInputs;
		inputs = new List<bool> (numInputs);
		outputObjectCount = 1;
		if (outputObjects.Count > 1) {
			throw new ArgumentException ();
		}
		outputs = outputObjects;
	}

	// Applys the module's logic to the input arraylist of booleans
	override public IList<bool> applyLogic(IList<bool> inputs) {
		bool output = inputs [0];
		for (int i = 1; i < inputs.Count; i++) {
			output = output & inputs [i];
		}
		List<bool> ls = new List<bool> ();
		ls.Add (output);
		return ls;
	}

	// Notifies the output LogicObjects of a set of inputs
	override public void notifyOutput (IList<bool> outputList) {
		outputs [0].notifyInput (outputList);
	}
}
