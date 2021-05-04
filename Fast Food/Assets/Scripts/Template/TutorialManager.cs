/* Team Knowledge 
 * Spring 2021 Group Game 2
 * Tutorial manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private AbstractTutorial currentTut;
    public AbstractTutorial startTut;
    
    // Start is called before the first frame update
    void Start()
    {
        NextTutorial(startTut);
    }

    public void NextTutorial(AbstractTutorial nextTut)
    {
        currentTut = nextTut;
        currentTut.PrintText();
    }
}
