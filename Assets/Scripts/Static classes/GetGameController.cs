using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetGameController
{
    private static GameController _gameCotroller;

    public static GameController _GetGameController
    {
        get
        {
            if(_gameCotroller == null)
                _gameCotroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            return _gameCotroller;
        }
    }
}
