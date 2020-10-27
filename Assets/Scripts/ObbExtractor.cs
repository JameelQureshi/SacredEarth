using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObbExtractor : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ExtractObbDatasets());
    }

    private IEnumerator ExtractObbDatasets()
    {
        string[] filesInOBB = { "RAMshow2019.dat", "RAMshow2019.xml" };
        foreach (var filename in filesInOBB)
        {
            string uri = Application.streamingAssetsPath + "/Vuforia/" + filename;

            string outputFilePath = Application.persistentDataPath + "/Vuforia/" + filename;
            if (!Directory.Exists(Path.GetDirectoryName(outputFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            var www = new WWW(uri);
            yield return www;

            Save(www, outputFilePath);
            yield return new WaitForEndOfFrame();
        }

        // When done extracting the datasets, Start Vuforia AR scene
        SceneManager.LoadScene("ECR_App_2019_4-15-2019");
    }

    private void Save(WWW w, string outputPath)
    {
        File.WriteAllBytes(outputPath, w.bytes);

        // Verify that the File has been actually stored
        if (File.Exists(outputPath))
        {
            Debug.Log("File successfully saved at: " + outputPath);
        }
        else
        {
            Debug.Log("Failure!! - File does not exist at: " + outputPath);
        }
    }
}