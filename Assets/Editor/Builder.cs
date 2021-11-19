using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

// Output the build size or a failure depending on BuildPlayer.

public class Builder : MonoBehaviour
{
	
	[MenuItem("Build/Build Android")]
	public static void BuildAndroid()
	{
		Debug.Log("[Build] Android Starting..");
		
		var outdir = System.Environment.CurrentDirectory + "/BuildOutPutPath/";
		var outputPath = Path.Combine(outdir, string.Format("Android/{0}-{1}({2}).apk", Application.productName, Application.version, PlayerSettings.Android.bundleVersionCode));

		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = new[] { "Assets/Scenes/MainScene.unity"};
		buildPlayerOptions.locationPathName = outputPath;
		buildPlayerOptions.target = BuildTarget.Android;
		buildPlayerOptions.options = BuildOptions.None;

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		Debug.LogFormat("[Build] Android Finish. Report: summary: {0}, errors: {1}", report.summary.result, report.summary.totalErrors);
		
		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("[Build] Android Success: path: " + summary.outputPath + ", size: " + (summary.totalSize/1000f) + " Kb");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.LogException(new Exception("[Build] Android Failed! Please Check the log! "));
		}
	}
	
	[MenuItem("Build/Build iOS")]
	public static void BuildIOS()
	{
		Debug.Log("[Build] iOS Starting..");

		var outdir = System.Environment.CurrentDirectory + "/BuildOutPutPath/";
		var outputPath = Path.Combine(outdir, string.Format("iOS/{0}-{1}({2})", Application.productName, Application.version, PlayerSettings.Android.bundleVersionCode));
		
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = new[] { "Assets/Scenes/MainScene.unity"};
		buildPlayerOptions.locationPathName = outputPath;
		buildPlayerOptions.target = BuildTarget.iOS;
		buildPlayerOptions.options = BuildOptions.None;

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		Debug.Log("[Build] iOS Finish. Report: " + report);
		
		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("[Build] iOS Success: path: " + summary.outputPath + ", size: " + (summary.totalSize/1000f) + " Kb");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.LogException(new Exception("[Build] iOS Failed! Please Check the log! "));
		}
	}
}