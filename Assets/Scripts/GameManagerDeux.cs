using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDeux : MonoBehaviour {

    
    public Renderer cubeRenderer;
    public Material[] materials;
    public int index;

    public static GameManagerDeux Instance;

    void Awake()
    {

        Instance = this;

    }

    void Start()
    {
        DataManagerDeux.Instance.Load();
        cubeRenderer.material = materials[index];
    }

    void Update()
    {
        MaterialChangeUpdate();
    }

    private void MaterialChangeUpdate()
    {
        // change la méthode pour avoir le score
        if (Input.GetMouseButtonDown(0))
        {

            cubeRenderer.material = materials[index];

            DataManagerDeux.Instance.Save();

            index++;


            if (index > materials.Length - 1)
            {
                index = 0;
            }


        }
    }

    public void OnApplicationPause(bool pause)
    {
        DataManagerDeux.Instance.Save();
    }
}
