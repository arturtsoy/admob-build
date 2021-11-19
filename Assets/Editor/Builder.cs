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
		buildPlayerOptions.scenes = new[] { "Assets/samples/HelloWorld/Assets/Scenes/MainScene.unity"};
		buildPlayerOptions.locationPathName = outputPath;
		buildPlayerOptions.target = BuildTarget.Android;
		buildPlayerOptions.options = BuildOptions.None;

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("[Build] Android Success: path: " + summary.outputPath + ", size: " + (summary.totalSize/1000f) + " Kb");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.LogException(new Exception("[Build] Android Failed! Please Check the log! "));
		}
		
		if (File.Exists(outputPath))
		{
			Debug.Log("[Build] Android CheckFileExist Success: path: " + outputPath);
		}
		else
		{
			Debug.LogException(new Exception("[Build] Android CheckFileExist Fail! Please Check the log! "));
		}
	}
	
	[MenuItem("Build/Build iOS")]
	public static void BuildIOS()
	{
		Debug.Log("[Build] iOS Starting..");

		var outdir = System.Environment.CurrentDirectory + "/BuildOutPutPath/";
		var outputPath = Path.Combine(outdir, string.Format("Android/{0}-{1}({2}).apk", Application.productName, Application.version, PlayerSettings.Android.bundleVersionCode));
		
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = new[] { "Assets/samples/HelloWorld/Assets/Scenes/MainScene.unity"};
		buildPlayerOptions.locationPathName = outputPath;
		buildPlayerOptions.target = BuildTarget.iOS;
		buildPlayerOptions.options = BuildOptions.None;

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("[Build] iOS Success: path: " + summary.outputPath + ", size: " + (summary.totalSize/1000f) + " Kb");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.LogException(new Exception("[Build] iOS Fail! Please Check the log! "));
		}
	}
}