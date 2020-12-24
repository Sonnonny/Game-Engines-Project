using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;


public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;
    public Rigidbody rb;
    public float moveSpeed;
    public float runMult;
    public LayerMask groundLayer;
    public float jumpPower;

    public float O2;
    public float oxLevel;
    public Image meter;

    public PostProcessVolume _volume;
    ColorGrading col;
    Bloom blo;
    //Vignette vig;
    Grain gra;
    //LensDistortion len;

    // Start is called before the first frame update
    void Start()
    {
        EffectSetup();
        Effects();
    }

    // Update is called once per frame
    void Update()
    {
        

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        //Vector3 jump = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.Raycast(transform.position, -transform.up, 2,groundLayer);


            rb.AddForce(transform.up *jumpPower, ForceMode.Impulse);
            //jump = new Vector3(0, 8, 0);
        }

        //rb.velocity += (moveDirection+jump )* moveSpeed * Time.deltaTime;
        float run = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = runMult;
        }

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * run* Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


        oxLevel -= Time.deltaTime;
        meter.fillAmount = oxLevel / O2;

        if (oxLevel <= 0)
        {
            SceneManager.LoadScene(0);
        }


    }

    private void EffectSetup()
    {


        col = ScriptableObject.CreateInstance<ColorGrading>();
        col.enabled.Override(true);
        col.saturation.Override(0);
        col.temperature.Override(0);
        col.tint.Override(0);
        col.hueShift.Override(0);
        _volume = PostProcessManager.instance.QuickVolume(8, 100f, col);

        blo = ScriptableObject.CreateInstance<Bloom>();
        blo.enabled.Override(true);
        blo.intensity.Override(0);
        _volume = PostProcessManager.instance.QuickVolume(8, 100f, blo);

        gra = ScriptableObject.CreateInstance<Grain>();
        gra.enabled.Override(true);
        gra.intensity.Override(0);
        gra.size.Override(0);
        _volume = PostProcessManager.instance.QuickVolume(8, 100f, gra);
    }

    private void Effects()
    {



        col.saturation.value = 100 * Mathf.RoundToInt(Random.value);
        col.temperature.value = Random.Range(-100.0f, 100.0f);
        col.tint.value = Random.Range(-100.0f, 100.0f);
        col.hueShift.value = Random.Range(-180.0f, 180.0f);
        col.postExposure.value = Random.Range(-2, 2);

        blo.intensity.value = Random.Range(0.2f, 3.0f);

        gra.intensity.value = Random.Range(0.02f, 0.7f);
        gra.size.value = Random.Range(0.2f, 2f);




        //_volume.profile.over
    }
}
