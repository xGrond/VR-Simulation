using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istifController : MonoBehaviour {


    public Material GreenMat;
    public Material YellowMat;
    [SerializeField] float endDelay;
    bool onayak, arkaayak, ortaayak, isActive;
    Renderer rend;
    [SerializeField] Renderer rendChild;
    float time;
    [SerializeField] UIControl UIControl;
    public MeshRenderer Yuk;
    public MeshRenderer[] Ayaklar;

    // Use this for initialization
    void Awake() {

        isActive = false;
        rend = this.gameObject.GetComponent<Renderer>();
        //rendChild = this.gameObject.GetComponentInChildren<Renderer>();
        
        colorGreen.a = 0.4f;
        colorYellow.a = 0.4f;
    }


    Color colorYellow = Color.yellow;
    Color colorGreen = Color.green;

    void ChangeAyaklarMatColor(Color color) {

        for (int i = 0; i < Ayaklar.Length; i++)
        {
            for (int x = 0; x < Ayaklar[i].materials.Length; x++)
            {
                Ayaklar[i].materials[x].color = color;
            }
        }
    }

    void ChangeMultipleMatColor(MeshRenderer Rend, Color Color) {
        for (int i = 0; i < Rend.materials.Length; i++)
        {
            Rend.materials[i].color = Color;
        }
    }

    // Update is called once per frame
    void Update() {
        if (onayak && arkaayak && ortaayak && !isActive) {
            // Green zone

            ChangeMultipleMatColor(Yuk, colorGreen);
            ChangeAyaklarMatColor(colorGreen);
            isActive = true;
        }

        if (isActive)
        {
            if (!onayak || !arkaayak || !ortaayak)
            {
                isActive = false;
                ChangeMultipleMatColor(Yuk, colorYellow);
                ChangeAyaklarMatColor(colorYellow);
                // Yellow zone
            }
        }
        // TODO: Red Zone
        Checker();
    }

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        {
            switch (name) {
                case "onAyak":
                    onayak = true;
                    break;
                case "arkaAyak":
                    arkaayak = true;
                    break;
                case "ortaAyak":
                    ortaayak = true;
                    break;
                default:
                    break;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        string name = other.gameObject.name;
        {
            switch (name)
            {
                case "onAyak":
                    onayak = false;
                    break;
                case "arkaAyak":
                    arkaayak = false;
                    break;
                case "ortaAyak":
                    ortaayak = false;
                    break;
                default:
                    break;
            }

        }
    }

    void Checker() {
        if (isActive)
        {
            time += Time.deltaTime;
            if (time > endDelay)
            {
                IstifOver();
            }
        }
        else {
            if (time != 0) time = 0f;
        }
        
    }

    void IstifOver() {
        //UIControl.ShowMission();
    }

    void materialControl() {

    }
}
