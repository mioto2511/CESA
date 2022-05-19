using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vibration(float left,float right,float time)
    {
        PriVibration(left,right,time);
    }

    private static IEnumerator PriVibration(float left, float right,float time)
    {
        var gamepad = Gamepad.current;

        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(left, right);
            yield return new WaitForSeconds(time);//ïbêî
            gamepad.SetMotorSpeeds(0, 0);
        }            
    }
}
