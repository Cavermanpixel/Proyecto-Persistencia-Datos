using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameNew;
    public TextMeshProUGUI nombreGuardado;
    public TextMeshProUGUI BtnGuardado;
    [SerializeField] GameObject llamada;
    private string Nombre;

    public void NewNameSelected()
    {
        if (nameNew.text.Length >1)
        {
            //Debug.Log(nameNew.text.Length);
            DontDestroyMenu.Instance.namePlayer = nameNew.text;
            
            Nombre = nameNew.text;
            nombreGuardado.text = "Hola " + Nombre + " ven a jugar";

        }
        else
        {
            Debug.Log("No hay nombre");
        }
    }

    public void Awake()
    {

        Nombre = DontDestroyMenu.Instance.namePlayer;
        Debug.Log(Application.persistentDataPath);

        if (Nombre.Length > 1)
        {
            BtnGuardado.text = "Cambiar";
            nombreGuardado.text = "Hola " + Nombre + " ven a jugar";

;        }
        else
        {
            BtnGuardado.text = "Guardar";
        }
    }

    public void StarNew()
    {
        if (Nombre.Length > 1)
        {
           
            SceneManager.LoadScene(1);

                   }
        else
        {
            llamada.SetActive(true);
        }
        
    }

    public void RecordTable()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

  
}
