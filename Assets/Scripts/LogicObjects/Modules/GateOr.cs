using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// A many-to-one OR gate.
/// </summary>
public class GateOr : LogicModule {
    public GateOr(int numInputs) : base(numInputs, 1) {

    }

    public override string getName() {
        return "Or";
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        bool? output = inputs[0];
        for (int i = 1; i < inputs.Count; i++) {
            output = output | inputs[i];
        }
        return LogicUtil.oneBoolList(output);
    }
}
