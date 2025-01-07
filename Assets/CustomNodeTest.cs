using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

[UnitTitle("Change Active State")]
[UnitCategory("Amrita Testing")]
public class CustomNodeTest : Unit
{

    [DoNotSerialize] [PortLabelHidden] private ControlOutput controlOutput;
    [DoNotSerialize] private ValueInput ObjectToActivivate, activeState;

    protected override void Definition()
    {
        ObjectToActivivate = ValueInput<GameObject>("Game Object", null);
        activeState = ValueInput<bool>("Is Active", false);

        ControlInputCoroutine("", CoroutineAction);

        IEnumerator CoroutineAction(Flow flow)
        {
            GameObject g = flow.GetValue<GameObject>(ObjectToActivivate);
            bool active = flow.GetValue<bool>(activeState);

            g.SetActive(active);


            yield return controlOutput;
        }

    }



}
