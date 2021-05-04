/* Team Knowledge 
 * Spring 2021 Group Game 2
 * Addon to tutorial foods to help keep track whats been eatened
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFoodDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            FoodT.foodCount++;
    }
}
