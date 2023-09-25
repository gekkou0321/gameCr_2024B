using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 100; // �X�R�A

    // GameManager�̃C���X�^���X���V���O���g���Ƃ��Ĉ������߂̕ϐ�
    private static GameManager instance;

    public Text scoreText; // �X�R�A��\������e�L�X�g

    // �E�̃Q�[�W�p�̃X���C�_�[
    public Slider rightSlider;

    // ���̃Q�[�W�p�̃X���C�_�[
    public Slider leftSlider;

    // Lcon �I�u�W�F�N�g
    public GameObject lconObject;

    // Rcon �I�u�W�F�N�g
    public GameObject rconObject;

    public GameObject swordObject;


    // ���C���R���g���[���[�ւ̎Q��
    public MainScene mainSceneScript;

    // �e�X�|�i�[�ւ̎Q��
    public BulletSpawner bspawnerL;
    public BulletSpawner bspawnerR;
    // GameManager�̃C���X�^���X���擾����v���p�e�B
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // �X�R�A�����Z����֐�
    public void AddScore(int amount)
    {
        score += amount;
    }

    // �X�R�A�����Z����֐�
    public void SubtractScore(int amount)
    {
        score -= amount;
        if (score < 0)
        {
            score = 0; // �X�R�A�����ɂȂ�Ȃ��悤�ɂ���
        }
    }

    // ���݂̃X�R�A���擾����֐�
    public int GetScore()
    {
        return score;
    }

    public void ModeChange(int mode) 
    {
        if (mode == 0) { 
            swordObject.SetActive(false); 
            rconObject.SetActive(true); lconObject.SetActive(true);
            rightSlider.gameObject.SetActive(true); leftSlider.gameObject.SetActive(true); 
            mainSceneScript.enabled = true; bspawnerL.enabled = true; bspawnerR.enabled = true;
        }
        if (mode == 1) { swordObject.SetActive(true); 
            rconObject.SetActive(false); lconObject.SetActive(false);
            rightSlider.gameObject.SetActive(false); leftSlider.gameObject.SetActive(false);
            mainSceneScript.enabled = false; bspawnerL.enabled = false; bspawnerR.enabled = false;
        }
    }


    private void Update()
    {
        // �X�R�A���e�L�X�g�ɔ��f
        scoreText.text = "SCORE: " + GetScore();

        if (Input.GetKey(KeyCode.B)) { ModeChange(1); }
        if (Input.GetKey(KeyCode.V)) { ModeChange(0); }
    }


    
}