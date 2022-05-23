using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    public bool hitstop_flg = false;

    private int count = 0;

    public int time = 1000;

    public float duration1 = 0.25f;

    public float magnitude1 = 0.1f;

    private bool count_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitstop_flg)
        {
            hitstop_flg = false;

            count_flg = true;

            Time.timeScale = 0.5f;
            Shake(duration1, magnitude1);
        }
    }

    private void FixedUpdate()
    {
        if (count_flg)
        {
            count++;

            if (count >= time)
            {
                //hitstop_flg = false;
                Time.timeScale = 1f;

                count_flg = false;

                count = 0;
                //Shake();
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
            
            
        //}

    }
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }

//    private IEnumerator Shake()
//    {
//        //Debug.Log("a");
//        Vector3 pos = this.transform.localPosition;

//        float elapsed = 0;

//        while (elapsed < duration)
//        {
//            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
//            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

//            transform.localPosition = new Vector3(x, y, pos.z);

//            elapsed += Time.deltaTime;
//            Debug.Log("a");

//            yield return null;
//        }

//        this.transform.localPosition = pos;
//    }
}
