﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun;

public class AppearPlayerName : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _text;

    public Player Player { get; private set; }



    public void SetPlayerInfo(Player player)
    {
        Player = player;
        _text.text = PhotonNetwork.NickName;
    }
   
}
