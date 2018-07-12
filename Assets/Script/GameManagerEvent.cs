using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour{


    /// <summary>
    ///Test
    /// </summary>
    int commitTest;

    public GameObject playButton;
    public GameObject stopButton;

    PlayerInfo playerPos;
    Vector2 nowPlayerPostion = new Vector2(0, 0);

    Coroutine playerCo;

    public void PlayButton()
    {
        ChangePalyButton(true);
        playerCo = StartCoroutine("PlayPlayer");
    }
    public void StopButton()
    {
        playerMotion = new List<ButtonStatus>();
        ChangePalyButton(false);
        StopCoroutine(playerCo);
        playerCo = null;
    }
    IEnumerator PlayPlayer()
    {
        Vector3 nowPos = playerPos.NowPlayerInfo();
        float rotateValue = 0;
        for (int i = 0; i < playerMotion.Count; ++i)
        {
            switch (playerMotion[i])
            {
                case ButtonStatus.leftSpin:
                    LeanTween.rotateLocal(userChar, new Vector3(0, userChatInfo.SetCharacterRotate(true), 0), 0.4f);
                    rotateValue = nowPos.z - 90;
                    break;
                case ButtonStatus.rightSpin:
                    LeanTween.rotateLocal(userChar, new Vector3(0, userChatInfo.SetCharacterRotate(false), 0), 0.4f);
                    rotateValue = nowPos.z + 90;
                    break;
                case ButtonStatus.roop:
                    break;
                case ButtonStatus.step:
                    Debug.Log(userChatInfo.nowDirection+"asdhflkd");
                    if (userChatInfo.nowDirection == Charater.UserDirection.North)
                    {
                        nowPlayerPostion.y += 1;
                    }
                    else if (userChatInfo.nowDirection == Charater.UserDirection.East)
                    {
                        nowPlayerPostion.x += 1;
                    }
                    else if (userChatInfo.nowDirection == Charater.UserDirection.South)
                    {
                        nowPlayerPostion.y -= 1;
                    }
                    else if (userChatInfo.nowDirection == Charater.UserDirection.West)
                    {
                        nowPlayerPostion.x -= 1;
                    }
                    playerPos = new PlayerInfo((int)nowPlayerPostion.x, (int)nowPlayerPostion.y);

                    if(playerPos.playerX >= 0 && playerPos.playerX < mapArr[0].Length && playerPos.playerY >= 0 && playerPos.playerY < mapArr.Length)
                    {
                        if (mapArr[playerPos.playerX][playerPos.playerY] == 1)
                        {
                            LeanTween.move(userChar, new Vector3(playerPos.playerX, 0.5f, playerPos.playerY), 0.5f);
                        }
                    }
                    
                    else
                    {
                        FailMotion();
                    }
                    break;
            }
            playerPos = new PlayerInfo((int)nowPos.x, (int)nowPos.y);
            yield return new WaitForSeconds(1.0f);

        }
    }
    void FailMotion()
    {
        LeanTween.moveY(userChar, 1, 0.2f);
        LeanTween.moveY(userChar, 0.5f, 0.2f).setDelay(0.2f);
    }

    void ChangePalyButton(bool on)
    {
        playButton.SetActive(on);
        stopButton.SetActive(!on);
    }

    void SetDirection()
    {

    }

   
}
