using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VRCharController : MonoBehaviour {

    public GameObject Forklift;
    public GameObject TeleporterScripts;
    public GameObject GetInGetoutButtons;
    public Transform ForkliftPlayerLoc;
    public GameObject MainPlayer;
    public GameObject SolExitPoint;
    public GameObject SagExitPoint;
    public MakeParent MakeParent;
    public GameObject SolControlKolu;
    public GameObject OrtaControlKolu;
    public GameObject SagControlKolu;
    NewCarUserControl ForkControl;
    Vector3 baseSolKolPos;
    Vector3 baseOrtaKolPos;
    Vector3 baseSagKolPos;
    public float delayTime;
    public bool timerActive, blockTeleport, IsForliftActive;
    float time;

    private void Start()
    {
        IsForliftActive = false;
        baseSolKolPos = SolControlKolu.transform.localPosition;
        baseOrtaKolPos = OrtaControlKolu.transform.localPosition;
        baseSagKolPos = SagControlKolu.transform.localPosition;
        ForkControl = GetComponent<NewCarUserControl>();
    }

    void incikTimer() {
        if (!timerActive) return;

        time += Time.deltaTime;
        //do smh
        if (time >= delayTime) {
            timerActive = false;
            time = 0;
        }
    }

    private void Update()
    {
        teleportBlocker();
        incikTimer();
    }

    void timerInitiator() {
        if (!timerActive) timerActive = true;
        else return;
    }

    void SetGameObjectFalse(GameObject obj) {
        obj.SetActive(false);
    }

    void SetGameObjectTrue(GameObject obj)
    {
        obj.SetActive(true);
    }


    public void ReplaceSolControlKol() {
        SolControlKolu.transform.localPosition = baseSolKolPos;
    }

    public void ReplaceOrtaControlKol()
    {
        OrtaControlKolu.transform.localPosition = baseOrtaKolPos;
    }

    public void ReplaceSagControlKol()
    {
        SagControlKolu.transform.localPosition = baseSagKolPos;
    }

    void MakeButtonsInvisible() {
        SetGameObjectFalse(GetInGetoutButtons);
    }

    void ChangePlayers()
    {


    }

    void MakeButtonsVisible() {
        SetGameObjectTrue(GetInGetoutButtons);

    }

    void teleportBlocker() {
        if (blockTeleport)
        {
            if (TeleporterScripts.activeSelf)
            {
                TeleporterScripts.SetActive(false);
            }
        }
        else return;
    }

    public void leftForklift(int val) {
        if (!IsForliftActive)
        {
            GetInToForklift();
        }

        else GetOutFromForklift(val);
    }

    // 0 = sol || 1 = sag

    public void solEtkin()
    {
        if (!timerActive)
        {
            inCik(0);
            timerInitiator();
        }
    }

    public void sagEtkin() {
        if (!timerActive)
        {
            inCik(1);
            timerInitiator();
        }
    }

    void inCik(int value)
    {

        if (!IsForliftActive)
        {
            if (value == 1 || value == 0)
            {
                GetInToForklift();
            }
        }

        if (IsForliftActive)
        {
            if (value == 0 && IsForliftActive)
            {
                GetOutFromForklift(0);
            }

            if (value == 1 && IsForliftActive)
            {
                GetOutFromForklift(1);
            }
        }
    } 

    void GetInToForklift()
    {
        MainPlayer.transform.position = ForkliftPlayerLoc.transform.position;
        MainPlayer.transform.parent = Forklift.transform;
        SetGameObjectFalse(TeleporterScripts);
        ForkControl.audioStart();
        IsForliftActive = true;
        blockTeleport = true;
        ForkControl.toucpadControl = true;
        //controlleri ac
    }

    void GetOutFromForklift(int val) {
        MainPlayer.transform.parent = null;
        IsForliftActive = false;
        if (val == 0) {
            MainPlayer.transform.position = SolExitPoint.transform.position;
        }

        if (val == 1) {
            MainPlayer.transform.position = SagExitPoint.transform.position;
        }
        ForkControl.toucpadControl = false;
        ForkControl.audioStop();
        blockTeleport = false;  
        SetGameObjectTrue(TeleporterScripts);

    }
}
