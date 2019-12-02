using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class VRUIController : MonoBehaviour {

    public Canvas istifUyari;
    public Image dofRap1;
    public Canvas dofRap2;
    public Text yolUyariText;
    bool timerActive;
    float time;
    public float delayTime;


    void showCanvas(Canvas canvas) {
        canvas.gameObject.SetActive(true);
    }

    void hideCanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }

    public void showIstifCanvas() {
        showCanvas(istifUyari);
    }

    public void hideIstifCanvas() {
        hideCanvas(istifUyari);
    }

    private void Update()
    {
        UItimer();
    }

    public void showYolUyari(){
        if (!yolUyariText.gameObject.activeSelf) {
            yolUyariText.gameObject.SetActive(true);
        }
    }

    public void hideYolUyari() {
        if (yolUyariText.gameObject.activeSelf)
        {
            yolUyariText.gameObject.SetActive(false);
        }
    }

    void UItimer() {
        if (!timerActive) return;

        time += Time.deltaTime;
        //do smh
        if (time >= delayTime)
        {
            hideDof1();
            timerActive = false;
            time = 0;
        }
    }

    public void showDof1() {
        dofRap1.gameObject.SetActive(true);
        timerActive = true;
    }

    void hideDof1()
    {
        dofRap1.gameObject.SetActive(false);
    }

    public void showDof2()
    {
        showCanvas(dofRap2);
    }

    public void hideDof2()
    {
        hideCanvas(dofRap2);
    }
}
