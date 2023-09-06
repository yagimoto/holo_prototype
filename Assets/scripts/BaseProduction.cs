using UnityEngine;
using UnityEngine.ProBuilder;

namespace DefaultNamespace
{
    public class BaseProduction
    {
        private static float beforeDis = -1f;
        private static Vector3 beforeScale = Vector3.one;

        private static GameObject MainCamera = GameObject.Find("Main Camera");
        
        public static void ChangeScale(GameObject gameObject)
        {
            if (Input.touchCount == 2)
            {
                if (beforeDis > 0)
                {
                    var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var scale = beforeScale * (dis / beforeDis);
                    gameObject.transform.localScale = scale;
                }
                else
                {
                    beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
            }
            if (Input.touchCount < 1 && beforeDis > 0)
            {
                beforeDis = -1f;
                beforeScale = gameObject.transform.localScale;
            }
            
        }

        public static void ChangePos(GameObject gameObject)
        {
            //前フレームからの指の移動量を取得し、その分だけオブジェクトを移動させる
            if (Input.touchCount == 1)
            {
                var n = MainCamera.transform.forward;
                var dis = Input.touches[0].deltaPosition.magnitude;
                
            }
            
        }
        public static void ChangeColor(GameObject gameObject, Color color)
        {
            gameObject.GetComponent<Renderer>().material.color = color;
        }

        public static void MergeObjects(GameObject[] gameObjects)
        {
            GameObject MergedObjects = new GameObject();
            
            foreach (var gameObject in gameObjects)
            {
                gameObject.transform.parent = MergedObjects.transform;
                
            }
        }
        
        
    }
        
}