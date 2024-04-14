//using UnityEditor;
//using UnityEngine;
//using System.IO;
//using System.Diagnostics;

//public class SceneViewSnapshot : MonoBehaviour
//{
//    [MenuItem("Tools/Capture Scene View")]
//    static void CaptureSceneViewMenuItem()
//    {
//        // Get the active SceneView
//        SceneView sceneView = SceneView.lastActiveSceneView;

//        if (sceneView != null)
//        {
//            Camera droneCamera = sceneView.camera; // Assuming DroneCamera is a property of SceneView

//            if (droneCamera != null)
//            {
//                int width = droneCamera.pixelWidth;
//                int height = droneCamera.pixelHeight;

//                Texture2D capture = new Texture2D(width, height);

//                droneCamera.Render();

//                RenderTexture.active = droneCamera.targetTexture;

//                capture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//                capture.Apply();

//                byte[] bytes = capture.EncodeToPNG();
//                string filename = "scenViewCapture.png";
//                File.WriteAllBytes(Application.dataPath + "/" + filename, bytes);

//                AssetDatabase.Refresh();
//            }
//        }
//    }
//}

