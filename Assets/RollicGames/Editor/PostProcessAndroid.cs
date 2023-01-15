#if UNITY_ANDROID
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace RollicGames.Editor
{
    public class PostProcessAndroid
    {
        [PostProcessBuild(207)]
        public static void UpdateLauncherManifest(BuildTarget target, string pathToBuiltProject)
        {
            var launcherManifestPath = Path.Combine(pathToBuiltProject, "launcher/src/main/AndroidManifest.xml");
            
            if (!File.Exists(launcherManifestPath)) return;
            
            string[] lines = File.ReadAllLines(launcherManifestPath);
            if (lines.Length == 0) return;
            
            File.Delete(launcherManifestPath);

            using (StreamWriter sw = File.AppendText(launcherManifestPath))
            {
                foreach (string line in lines)
                {
                    string newLine = "";
                    
                    if (line.Contains("com.google.android.gms.ads.APPLICATION_ID"))
                    {
                        newLine = line.Replace("com.google.android.gms.ads.APPLICATION_ID", "xxx");
                    }
                    else
                    {
                        newLine = line;
                    }
                    sw.WriteLine(newLine);
                }
            }
        }
    }
}
#endif