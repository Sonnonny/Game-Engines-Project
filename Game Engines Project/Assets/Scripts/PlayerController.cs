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

    private PostProcessVolume _volume;
    ColorGrading col;
    Bloom blo;
    //Vignette vig;
    Grain gra;
    //LensDistortion len;

    // Start is called before the first frame update
    void Start()
    {
        EffectSetup();
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
        col.hueShift.Override(15);
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


        col.saturation.value = Random.Range(0, 100.0f);
        col.temperature.value = 0;
        blo.intensity.value = Random.Range(1,9.0f);
        gra.intensity.value = Random.Range(0.02f, 0.5f);
        gra.size.value = Random.Range(0.2f, 0.5f);
    }
}
