using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ForkController : MonoBehaviour {

    public Transform fork; 
    public Transform mast;
    public Transform solMakas;
    public Transform sagMakas;
    public float speedTranslate; //Platform travel speed
    public Vector3 maxY; //The maximum height of the platform
    public Vector3 minY; //The minimum height of the platform
    public Vector3 maxYmast; //The maximum height of the mast
    public Vector3 minYmast; //The minimum height of the mast
    public Vector3 makasMinSol; //Makasin yakinligi
    public Vector3 makasMaxSol;
    public Vector3 makasMaxSag; //Makasin uzakligi
    public Vector3 makasMinSag; //Makasin yakinligi
    

    private bool mastMoveTrue = false; //Activate or deactivate the movement of the mast

    // Update is called once per frame
    void FixedUpdate () {
        if(fork.transform.localPosition.y >= maxYmast.y)
        {
            mastMoveTrue = true;
        }
        if (fork.transform.localPosition.y <= maxYmast.y)
        {
            mastMoveTrue = false;
        }
        if (fork.transform.localPosition.y >= maxY.y )
        {
            fork.transform.localPosition = new Vector3(fork.transform.localPosition.x, maxY.y, fork.transform.localPosition.z);
        }

          if (fork.transform.localPosition.y <= minY.y)
          {
              fork.transform.localPosition= new Vector3(fork.transform.localPosition.x, minY.y, fork.transform.localPosition.z);
          }
        if (mast.transform.localPosition.y >= maxYmast.y)
        {
            mast.transform.localPosition= new Vector3(mast.transform.localPosition.x, maxYmast.y, mast.transform.localPosition.z);
        }

        if (mast.transform.localPosition.y <= minYmast.y)
        {
            mast.transform.localPosition = new Vector3(mast.transform.localPosition.x, minYmast.y, mast.transform.localPosition.z);
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
           fork.Translate(Vector3.up * speedTranslate * Time.deltaTime);
            if(mastMoveTrue)
            {
                //mast.Translate(Vector3.up * speedTranslate * Time.deltaTime);
            }
          
        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            fork.Translate(-Vector3.up * speedTranslate * Time.deltaTime);
            if(mastMoveTrue)
            {
                //mast.Translate(-Vector3.up * speedTranslate * Time.deltaTime);
            }
            
        }

    }

    private void Update()
    {
     
    }

    public void makasIceri()
    {
        if (solMakas.transform.localPosition.x <= makasMinSol.x && sagMakas.transform.localPosition.x >= makasMinSag.x)
        {
            solMakas.transform.Translate(Vector3.right * speedTranslate * Time.deltaTime);
            sagMakas.transform.Translate(Vector3.left * speedTranslate * Time.deltaTime);
        }
    }

    public void makasDisari() {
        if (solMakas.transform.localPosition.x >= makasMaxSol.x && sagMakas.transform.localPosition.x <= makasMaxSag.x)
        {
            solMakas.transform.Translate(Vector3.left * speedTranslate * Time.deltaTime);
            sagMakas.transform.Translate(Vector3.right * speedTranslate * Time.deltaTime);
        }
    }

    public void makasSol()
    {
        if (solMakas.transform.localPosition.x >= makasMaxSol.x) {
            solMakas.transform.Translate(Vector3.left * speedTranslate * Time.deltaTime);
            sagMakas.transform.Translate(Vector3.left * speedTranslate * Time.deltaTime);
        }
    }

    public void makasSag()
    {
        if (sagMakas.transform.localPosition.x <= makasMaxSag.x)
        {
            solMakas.transform.Translate(Vector3.right * speedTranslate * Time.deltaTime);
            sagMakas.transform.Translate(Vector3.right * speedTranslate * Time.deltaTime);
        }
    }

    public void makasUp()
    {
        fork.Translate(Vector3.up * speedTranslate * Time.deltaTime);
        if (mastMoveTrue)
        {
            //mast.Translate(Vector3.up * speedTranslate * Time.deltaTime);
        }

    }

    public void makasDown()
    {
        fork.Translate(-Vector3.up * speedTranslate * Time.deltaTime);
        if (mastMoveTrue)
        {
            //mast.Translate(-Vector3.up * speedTranslate * Time.deltaTime);
        }

    }
}
