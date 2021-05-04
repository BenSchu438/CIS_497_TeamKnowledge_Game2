/* Team Knowledge 
 * Spring 2021 Group Game 2
 * abstract Tutorial supertype (template)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractTutorial : MonoBehaviour
{
    public TutorialManager manager;
    public GameObject tutText;
    public AbstractTutorial nextTut;

    public void PrintText()
    {
        tutText.SetActive(true);
        CheckProgress();
    }

    protected abstract void CheckProgress();

    protected void SetNextTutorial()
    {
        tutText.SetActive(false);
        manager.NextTutorial(nextTut);
    }
}
