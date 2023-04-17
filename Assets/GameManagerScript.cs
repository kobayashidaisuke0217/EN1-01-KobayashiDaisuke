using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //配列の宣言
    int[] map;


    //クラスの中メソッドの外に書く
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //文字列を結合
            debugText += map[i].ToString() + ",";

        }
        //結合した文字列を出力
        Debug.Log(debugText);
    }
    int GetPlayerIndex()
    {
        for(int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }
    bool Movenumber(int number,int moveFrom,int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            //動けない条件を先に書きリターンする。早期リターン
            return false;
        }
        if (map[moveTo] == 2)
        {
            //どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;
            //プレイヤーの移動先から、さらに箱を移動させる
            //箱の移動処理.MoveNumberメソッド内でMoveNumberメソッドを呼び
            //処理が再起している。移動可不可をboolで記録
            bool success = Movenumber(2, moveTo, moveTo + velocity);
            //  もし箱が移動失敗したらプレイヤーの移動も失敗
            if (!success) { return false; }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;

    }
    // Start is called before the first frame update
    void Start()
    {
        //配列の実態の作成と初期化
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

        /*//デバッグログの表示
        Debug.Log("Hello,World!");
        */
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        //見つからなかったときのために1で初期化
        int playerIndex = GetPlayerIndex();
        //for (int i = 0; i < map.Length; i++)
        //{
        //    if (map[i] == 1)
        //    {
        //        playerIndex = i;
        //        break;
        //    }
        //}
        /*
         PlayerIndex+1のインデクスの物と交換するので、
        playerIndex-1よりさらに小さいインデックスの時のみ交換処理を行う
         */

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //if (playerIndex < map.Length - 1)
            //{
            //    map[playerIndex + 1] = 1;
            //    map[playerIndex] = 0;
            //文字列の追加と初期化
            //移動処理を関数化
            Movenumber(1, playerIndex, playerIndex + 1);
                PrintArray();
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
                //移動処理を関数化
                Movenumber(1, playerIndex, playerIndex - 1);
                PrintArray();
            
        }

    }
}