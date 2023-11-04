using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public GameObject TutorialCanvas1;
    public GameObject TutorialCanvas2;
    public GameObject TutorialCanvas3;
    public GameObject TutorialCanvas4;

    public CameraController cameraController;
    public GameObject BigWall;

    public void Next1()
    {
        TutorialCanvas1.SetActive(false);
        TutorialCanvas2.SetActive(true);
    }
    public void Next2()
    {
        TutorialCanvas2.SetActive(false);
        TutorialCanvas3.SetActive(true);
    }
    public void Next3()
    {
        TutorialCanvas3.SetActive(false);
        TutorialCanvas4.SetActive(true);
    }
    public void Next4()
    {
        TutorialCanvas4.SetActive(false);
        cameraController._camSpeed = 1;
        BigWall.SetActive(false);
    }




}
