using System;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

    [RequireComponent(typeof (NewCarController))]
public class NewCarUserControl : MonoBehaviour
    {
        private NewCarController m_Car; // the car controller we want to use

    public SteamVR_Action_Vector2 touchPadValue;
    Rigidbody rb;

    [Tooltip("Deger True ise keyboard inputu acik")] public bool isTesting;

    public LinearMapping SteeringDrive;
    public ForkController makasController;
    public LinearMapping solKolInput;
    public LinearMapping ortaKolInput;
    public LinearMapping sagKolInput;
    public LinearMapping gasValue;
    AudioSource forkliftAudio;
    public AudioClip ileri, geri, idle;
    public bool reverseMode, toucpadControl, moving, oldMoving;
    float steering;
    float throttle;
    VRCharController charController;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<NewCarController>();
        rb = GetComponent<Rigidbody>();
        forkliftAudio = GetComponent<AudioSource>();
        reverseMode = false;
        toucpadControl = false;
        charController = GetComponent<VRCharController>();
        }

    //void GetSteeringInput() {
    //    steering = (2 * SteeringDrive.value) - 1;
    //} 

    float GetSteeringInput() {
        Vector2 steering = touchPadValue.GetAxis(SteamVR_Input_Sources.LeftHand);
        return steering.x;
    }

    float GetThrottleInput() {
        Vector2 throttle = touchPadValue.GetAxis(SteamVR_Input_Sources.RightHand);
        if (throttle.y > 0f) {
            if (reverseMode) return -throttle.y;
            else return throttle.y;
        }
        else return 0;
    }

    float GetThrottleBreak()
    {
        Vector2 throttle = touchPadValue.GetAxis(SteamVR_Input_Sources.RightHand);
        if(throttle.y < 0f) return -throttle.y;
        else return 0;
    }

    void setAudio(AudioClip ac) {
        forkliftAudio.clip = ac;
        forkliftAudio.Play();
    }

    void AudioControl() {
        if (charController.IsForliftActive) {
            if (GetThrottleInput() != 0)
            {
                if (!reverseMode && forkliftAudio.clip.name != ileri.name) setAudio(ileri);
                if (reverseMode && forkliftAudio.clip.name != geri.name) setAudio(geri);
            }
            if (GetThrottleInput() == 0 && forkliftAudio.clip.name != idle.name) setAudio(idle);
        }
    }

    public void audioStart() {
        forkliftAudio.Play();
    }

    public void audioStop()
    {
        forkliftAudio.Stop();
    }

    // TODO: Set the stick
    public void vites() {
        // Change rotation and pos
        reverseMode = !reverseMode;
    }

    private void Update()
    {
        AudioControl();
        solKolEtkilesim();
        ortaKolEtkilesim();
    }

    void solKolEtkilesim() {
        float solKolValue = solKolInput.value;

        if (solKolValue == 1)
        {
            makasController.makasUp();
        }

        if (solKolValue == 0)
        {
            makasController.makasDown();
        }

    }

    void ortaKolEtkilesim()
    {
        float ortaKolValue = ortaKolInput.value;

        if (ortaKolValue == 1)
        {
            makasController.makasSag();
        }

        if (ortaKolValue == 0)
        {
            makasController.makasSol();
        }

    }

    float v;
    float h;

    private void FixedUpdate()
        {



        if (toucpadControl)
        {
            v = GetThrottleInput();
            h = -GetSteeringInput();
        }

        if (isTesting) {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

#if !MOBILE_INPUT
        //
            float handbrake = GetThrottleBreak();
            m_Car.Move(h, v, v, handbrake);
            
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }

