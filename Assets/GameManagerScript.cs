using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //�z��̐錾
    int[] map;


    //�N���X�̒����\�b�h�̊O�ɏ���
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //�����������
            debugText += map[i].ToString() + ",";

        }
        //����������������o��
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
            //�����Ȃ��������ɏ������^�[������B�������^�[��
            return false;
        }
        if (map[moveTo] == 2)
        {
            //�ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;
            //�v���C���[�̈ړ��悩��A����ɔ����ړ�������
            //���̈ړ�����.MoveNumber���\�b�h����MoveNumber���\�b�h���Ă�
            //�������ċN���Ă���B�ړ��s��bool�ŋL�^
            bool success = Movenumber(2, moveTo, moveTo + velocity);
            //  ���������ړ����s������v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;

    }
    // Start is called before the first frame update
    void Start()
    {
        //�z��̎��Ԃ̍쐬�Ə�����
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

        /*//�f�o�b�O���O�̕\��
        Debug.Log("Hello,World!");
        */
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        //������Ȃ������Ƃ��̂��߂�1�ŏ�����
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
         PlayerIndex+1�̃C���f�N�X�̕��ƌ�������̂ŁA
        playerIndex-1��肳��ɏ������C���f�b�N�X�̎��̂݌����������s��
         */

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //if (playerIndex < map.Length - 1)
            //{
            //    map[playerIndex + 1] = 1;
            //    map[playerIndex] = 0;
            //������̒ǉ��Ə�����
            //�ړ��������֐���
            Movenumber(1, playerIndex, playerIndex + 1);
                PrintArray();
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
                //�ړ��������֐���
                Movenumber(1, playerIndex, playerIndex - 1);
                PrintArray();
            
        }

    }
}