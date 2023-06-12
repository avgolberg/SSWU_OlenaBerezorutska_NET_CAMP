using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeSort
{
    class MergeSort
    {
        private const int SIZE_LIMIT = 50;

        public MergeSort(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path can not be null or empty");

            if (!File.Exists(path))
                throw new ArgumentException("File does not exist");

            if (new FileInfo(path).Length == 0)
                throw new ArgumentException("File can not be empty");

            string tempDir = @"..\..\..\Temps";
            Directory.CreateDirectory(tempDir);

            PartialSort(path);
            ExternalMerge(path, Directory.GetFiles(tempDir));

            DeleteDirectory(tempDir);
        }
     
        private void PartialSort(string path)
        {
            int[] items = new int[SIZE_LIMIT];
            int part = 0;
            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    for (int i = 0; i < SIZE_LIMIT; i++)
                    {
                        items[i] = Convert.ToInt32(streamReader.ReadLine());
                    }
                    Array.Sort(items);
                    File.WriteAllText(@$"..\..\..\Temps\temp_{++part}.txt", string.Join("\n", items));
                }
            }
        }

        private void ExternalMerge(string resPath, string[] mergeFiles)
        {
            if(mergeFiles.Length > SIZE_LIMIT)
                throw new ArgumentException("Merge Files count is greater than Size Limit");

            List<StreamReader> streamReaders = new List<StreamReader>();
            foreach (var mergeFile in mergeFiles)
            {
                streamReaders.Add(File.OpenText(mergeFile));
            }

            using (StreamWriter sw = new StreamWriter(resPath, false))
            {
                List<int> values = streamReaders.Select(sr => Convert.ToInt32(sr.ReadLine())).ToList();
                while (streamReaders.Any())
                {
                    int index = values.IndexOf(values.Min());
                    var minSR = streamReaders.ElementAt(index);
                    sw.WriteLine(values[index]);

                    if (!minSR.EndOfStream)
                    {
                        values[index] = Convert.ToInt32(minSR.ReadLine());
                    }
                    else
                    {
                        minSR.Close();
                        streamReaders.Remove(minSR);
                        values.RemoveAt(index);
                    }                
                }
            }
        }

        private void DeleteDirectory(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            Directory.Delete(dir);
        }
    }
}
