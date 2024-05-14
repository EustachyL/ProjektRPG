using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // Subskrybujesz do zdarzenia �adowania sceny
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Ta funkcja zostanie wywo�ana po za�adowaniu nowej sceny
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Wywo�aj tutaj swoj� funkcj�
        MojaFunkcja();
    }

    // Funkcja, kt�r� chcesz wywo�a� po za�adowaniu sceny
    void MojaFunkcja()
    {
        // Tutaj umie�� kod, kt�ry ma zosta� wykonany po za�adowaniu sceny
        UnityEngine.Debug.Log("Scena zosta�a za�adowana. Wywo�ano moj� funkcj�.");
    }

    // Pami�taj o odsubskrybowaniu zdarzenia po zako�czeniu
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
