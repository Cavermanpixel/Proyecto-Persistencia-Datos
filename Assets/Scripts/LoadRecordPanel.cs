using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRecordPanel : MonoBehaviour
{
    public TextMeshProUGUI textMostrar;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while (i<5)
        {
            foreach (records aPart in DontDestroyMenu.Instance.nuevosRecords)
            {
                var textoGui = Instantiate(textMostrar);
                textoGui.transform.parent = this.transform;
                textoGui.text = DontDestroyMenu.Instance.nuevosRecords[i].ToString();
                i++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
