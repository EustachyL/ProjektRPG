using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePush : MonoBehaviour
{
    // Referencja do obiektu b
  // Referencja do obiektu b
    public GameObject objectB;

    // Zmienna do przechowywania początkowej pozycji obiektu b
    private Vector3 initialPositionB;

    void Start()
    {
        // Zapisz początkową pozycję obiektu b
        if (objectB != null)
        {
            initialPositionB = objectB.transform.position;
        }
    }

    // Funkcja wywoływana przy kolizji
    private void OnTriggerEnter(Collider other)
    {
        // Sprawdź, czy obiekt, który wszedł w kolizję, ma tag "Player"
        if (other.CompareTag("Player"))
        {
            // Przesuń obiekt b o 10 jednostek w górę
            if (objectB != null)
            {
                objectB.transform.position += new Vector3(0f, 0.260f, 0f);
            }

                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                if (playerStats != null)
                {           
                    playerStats.TakeDamage(10.0);
                }
        }
    }

    // Funkcja wywoływana przy zakończeniu kolizji
    private void OnTriggerExit(Collider other)
    {
        // Sprawdź, czy obiekt, który zakończył kolizję, ma tag "Player"
        if (other.CompareTag("Player"))
        {
            // Wróć obiekt b do jego początkowej pozycji
            if (objectB != null)
            {
                objectB.transform.position = initialPositionB;
            }
        }
    }
}