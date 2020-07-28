using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData{
    public int[] repayment = new int[12];
    public int keepIndex = 99;
    public float restTime_minutes = 300;

    public int playTime_s = 0;
    public int playTime_m = 0;
    public int playTime_h = 0;
    public PlayerData() {
        for (int i = 0; i < 12; i++) {
            repayment[i] = 0;
        }
    }
}
