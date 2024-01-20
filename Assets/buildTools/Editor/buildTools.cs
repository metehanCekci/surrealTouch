using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEditor.PlayerSettings;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using Unity.EditorCoroutines.Editor;

public class buildTools : EditorWindow
{
    [MenuItem("Tools/Build Tools")]
    public static void onShowTools()
    {
        EditorWindow.GetWindow<buildTools>();
    }

    private BuildTargetGroup GetTargetGroupForTarget(BuildTarget target) => target switch
    {
        BuildTarget.StandaloneOSX => BuildTargetGroup.Standalone,
        BuildTarget.StandaloneWindows => BuildTargetGroup.Standalone,
        BuildTarget.iOS => BuildTargetGroup.iOS,
        BuildTarget.Android => BuildTargetGroup.Android,
        BuildTarget.StandaloneWindows64 => BuildTargetGroup.Standalone,
        BuildTarget.WebGL => BuildTargetGroup.WebGL,
        BuildTarget.StandaloneLinux64 => BuildTargetGroup.Standalone,
        _ => BuildTargetGroup.Unknown
    };
    Dictionary<BuildTarget, bool> TargetsToBuild = new Dictionary<BuildTarget, bool>();
    List<BuildTarget> AvaibleTargets = new List<BuildTarget>();
    private void OnEnable()
    {
        AvaibleTargets.Clear();
        var buildTargets = System.Enum.GetValues(typeof(BuildTarget));
        foreach(var buildTargetValue in buildTargets) 
        {
            BuildTarget target = (BuildTarget)buildTargetValue;

            //skip if unspoported
            if (!BuildPipeline.IsBuildTargetSupported(GetTargetGroupForTarget(target),target))
            {
                continue;
            }
            AvaibleTargets.Add(target);
            //add the target if not in the build list
            if (!TargetsToBuild.ContainsKey(target))
            {
                TargetsToBuild[target] = false;
            }
        }

        //check if any targets have gone away
        if (TargetsToBuild.Count > AvaibleTargets.Count)
        {
            //build the list of removed targets
            List<BuildTarget> targetsToRemove = new List<BuildTarget>();
            foreach(var target in TargetsToBuild.Keys)
            {
                if (!AvaibleTargets.Contains(target))
                {
                    targetsToRemove.Add(target);
                }
            }
            //cleanup the removed targets
            foreach (var target in targetsToRemove)
            {
                TargetsToBuild.Remove(target);
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Platforms to Build", EditorStyles.boldLabel);

        //display the build targets
        int numEnabled = 0;
        foreach (var target in AvaibleTargets)
        {
            TargetsToBuild[target] = EditorGUILayout.Toggle(target.ToString(), TargetsToBuild[target]);

            if (TargetsToBuild[target])
            {
                numEnabled++;
            }
        }
        if (numEnabled>0)
        {
            //attempt to build?
            string prompt = numEnabled == 1 ? "Build 1 Platform" : $"Build All{numEnabled} Platforms";
            if (GUILayout.Button(prompt))
            {
                List<BuildTarget> selectedTargets = new List<BuildTarget>();
                foreach (var target in AvaibleTargets)
                {
                    if (TargetsToBuild[target])
                    {
                        selectedTargets.Add(target);
                    }


                }

                EditorCoroutineUtility.StartCoroutine(PerformBuild(selectedTargets), this);
            }
        }
    }
    IEnumerator PerformBuild(List<BuildTarget> targetsToBuild)
    {
        // show the progress display
        int buildAllProgressID = Progress.Start("Build All", "Building all selected platforms", Progress.Options.Sticky);
        Progress.ShowDetails();
        yield return new EditorWaitForSeconds(1f);

        // build each target
        for (int targetIndex = 0; targetIndex < targetsToBuild.Count; ++targetIndex)
        {
            var buildTarget = targetsToBuild[targetIndex];

            int buildTaskProgressID = Progress.Start($"Build {buildTarget.ToString()}", null, Progress.Options.Sticky, buildAllProgressID);
            yield return new EditorWaitForSeconds(1f);

            Progress.Finish(buildTaskProgressID, Progress.Status.Succeeded);
            yield return new EditorWaitForSeconds(1f);
        }

        Progress.Finish(buildAllProgressID, Progress.Status.Succeeded);

        yield return null;
    }
}
