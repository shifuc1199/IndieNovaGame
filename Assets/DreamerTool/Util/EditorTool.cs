using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamerTool.EditorTool
{
#if UNITY_EDITOR
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    using System.Linq;

    public class AssetDataBaseManager
    {
        public static string GetScriptPath(string assetName)
        {
            var path = AssetDatabase.FindAssets(assetName);
            if (path.Length > 1)
            {
                Debug.LogError(assetName+"有同名文件，查找失败！");
            }
            else if (path.Length == 0)
            {
                   Debug.LogError("没找到,查找失败！");
            }
            string _path = AssetDatabase.GUIDToAssetPath(path[0]);
            return _path;
        }
    }
    
    public class SpriteToSplit
    {
        
        /// <summary>
        /// 切割Sprite导出单个对象
        /// </summary>
        [MenuItem("DreamTool/SpriteSplit2Export", false, 12)]
        public static void SpriteChildToExport()
        {
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                //获得选择对象路径;
                string spritePath = AssetDatabase.GetAssetPath(Selection.objects[i]);
                //所有子Sprite对象;
                Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spritePath).OfType<Sprite>().ToArray();
                if (sprites.Length < 1)
                {
                    EditorUtility.DisplayDialog("错误", "当前选择文件不是Sprite!", "确认");
                    Debug.LogError("Sorry,There is not find sprite!");
                    return;
                }
                string[] splitSpritePath = spritePath.Split(new char[] { '/' });
                //文件夹路径 通过完整路径再去掉文件名称即可;
                string fullFolderPath = Inset(spritePath, 0, splitSpritePath[splitSpritePath.Length - 1].Length + 1) + "/" + Selection.objects[i].name;
                //同名文件夹;
                string folderName = Selection.objects[i].name;
                string adjFolderPath = InsetFromEnd(fullFolderPath, Selection.objects[i].name.Length + 1);
                //验证路径;
                if (!AssetDatabase.IsValidFolder(fullFolderPath))
                {
                    AssetDatabase.CreateFolder(adjFolderPath, folderName);
                }

                for (int j = 0; j < sprites.Length; j++)
                {   //进度条;
                    string pgTitle = (i + 1).ToString() + "/" + Selection.objects.Length + " 开始导出Sprite";
                    string info = "当前Srpte: " + j + "->" + sprites[j].name;
                    float nowProgress = (float)j / (float)sprites.Length;
                    EditorUtility.DisplayProgressBar(pgTitle, info, nowProgress);
                    //创建Texture;
                    Sprite sprite = sprites[j];
                    Texture2D tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, sprite.texture.format, false);
                    tex.SetPixels(sprite.texture.GetPixels((int)sprite.rect.xMin, (int)sprite.rect.yMin,
                        (int)sprite.rect.width, (int)sprite.rect.height));
                    tex.Apply();
                    //判断保存路径;
                    string savePath = fullFolderPath + "/" + sprites[j].name + ".png";
 
                    //生成png;
                    File.WriteAllBytes(savePath, tex.EncodeToPNG());
                }
                //释放进度条;
                EditorUtility.ClearProgressBar();
               
                //刷新资源，不然导出后你以为没导出，还要手动刷新才能看到;
                AssetDatabase.Refresh();
            }
        }
        /// <summary>
        /// 截取路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="leftIn">左起点</param>
        /// <param name="rightIn">右起点</param>
        /// <returns></returns>
        public static string Inset(string path, int leftIn, int rightIn)
        {
 
            return path.Substring(leftIn, path.Length - rightIn - leftIn);
        }
        /// <summary>
        /// 截取路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="inset"></param>
        /// <returns></returns>
        public static string InsetFromEnd(string path, int inset)
        {
            return path.Substring(0, path.Length - inset);
        }
    }
#endif
}
