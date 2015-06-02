using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

    //public Vector3 difference;
    //float differenceX = 0.0f;
    public GameObject m_target;
    public GameObject m_player;

	// Use this for initialization
	void Start () {
        //// ゲーム開始時のカメラの位置
        //difference = transform.localPosition;
        //target = 0;
       // differenceX = difference.x;
	}
	
	// Update is called once per frame
    void Update()
    {
        // Playerの座標を取得
        Vector3 player_pos = m_player.transform.localPosition;
        //// Enemyの座標を取得
        Vector3 enemy_pos = m_target.transform.localPosition;
        //Vector3 camera_pos = new Vector3();
        //Vector3 taget_pos = enemy;
        // Sphereの角度を取得
        //Quaternion startRot = GameObject.Find("Player").transform.localRotation;

        // プレイヤーと敵
        float radian = Mathf.Atan2(enemy_pos.z - player_pos.z, player_pos.x - enemy_pos.x);
        float angle = radian * 180.0f / Mathf.PI;
        float distance = getDistance(player_pos.x, player_pos.z, enemy_pos.x, enemy_pos.z);
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        float x = Mathf.Cos(-radian) * (distance + 5.0f);
        float z = Mathf.Sin(-radian) * (distance + 5.0f);

        // プレイヤーの位置に固定
        transform.localPosition = new Vector3(enemy_pos.x + x/* + differenceX*/, player_pos.y + 2.0f/* + difference.y*/, enemy_pos.z + z/* + difference.z*/);

        //transform.localPosition = player_pos;

        // ターゲットの切り替え
        //if (Input.GetKey("tab"))
        //{
        //    if (target == 0)
        //    {
        //        target = 1;
        //        enemy = GameObject.Find("Cube2").transform.localPosition;
        //    }
        //    else
        //    {
        //        target = 0;
        //        enemy = GameObject.Find("Cube1").transform.localPosition;
        //    }
        //}

        // カメラが常に敵のポジションを向くように
        transform.LookAt(enemy_pos);

        //transform.LookAt(m_target.transform.position);
    }

    float getDistance(float x, float z, float x2, float z2)
    {
        float distance = Mathf.Sqrt((x2 - x) * (x2 - x) + (z2 - z) * (z2 - z));
        return distance;
    }
}
