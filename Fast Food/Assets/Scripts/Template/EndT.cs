/* Team Knowledge 
 * Spring 2021 Group Game 2
 * concrete tutorial template. Tells player how to exit tutorial and pause menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndT : AbstractTutorial
{
    private void Start()
    {
        tutText.SetActive(false);
    }

    protected override void CheckProgress()
    {
        // nothing. player completed tutorial. Wait for them to exit tutorial. 
    }

}