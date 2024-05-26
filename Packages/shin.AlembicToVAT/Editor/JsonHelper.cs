using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

namespace shin.AlembicToVAT
{
    public class JsonHelper
    {
        public string _filename;
        public string _filepath;

        public JsonHelper()
        {
            var time = DateTime.Now;
            _filename = $"{time.Year}{time.Month}{time.Day}_{time.Hour}{time.Minute}{time.Second}";
            _filepath = Application.dataPath + "/VATdata";
        }

        public JsonHelper(string filepath, string filename)
        {
            _filepath = filepath;
            _filename = filename + ".json";
        }

        private void FolderSetting(string pathFromAssets, string pathWithFile)
        {
            if (!System.IO.Directory.Exists(pathFromAssets))
            {
                System.IO.Directory.CreateDirectory(pathFromAssets);
            }

            if(!System.IO.File.Exists(pathWithFile))
            {
                System.IO.File.Create(pathWithFile);
            }
        }

        public void CreateJson(JsonData jsonData)
        {
            string writePath = $"{_filepath}/{_filename}";
            string jsonStr = JsonUtility.ToJson(jsonData);

            Debug.Log(writePath);

            FolderSetting(_filepath, writePath);

            var fileStream = new FileStream(writePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
            {
                writer.Write(jsonStr);
            }
        }
    }
}