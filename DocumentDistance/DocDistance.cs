using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections;

namespace DocumentDistance
{

    class DocDistance
    {
        // ***************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // ***************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static string readData(string path)
        {
            string text = "";
            text = File.ReadAllText(path).ToLower();
            return text;
        }
        public static Dictionary<string, long> processFile(string data)
        {
            Dictionary<string, long> dictWordCount = new Dictionary<string, long>();
            Regex regex = new Regex("[^A-Za-z0-9]", RegexOptions.Compiled);
            string result = regex.Replace(data, " ");
            string[] words = result.Split(' ');
            foreach (string word in words)
            {
                if (dictWordCount.ContainsKey(word))
                {
                    dictWordCount[word] += 1;
                }
                else if(!word.Equals(""))
                {
                    dictWordCount.Add(word, 1);
                }
            }
            return dictWordCount;
        }
        public static double getInnerProduct(Dictionary<string, long> dict1, Dictionary<string, long> dict2)
        {
            double sum = 0;
            foreach (string key in dict1.Keys)
            {
                if (dict2.ContainsKey(key))
                {
                    sum += dict1[key] * dict2[key];
                }
            }
            return sum;
        }
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            string data1 = readData(doc1FilePath);
            Dictionary<string, long> dicount1 = processFile(data1);
            string data2 = readData(doc2FilePath);
            Dictionary<string, long> dicount2 = processFile(data2);
            double innerProductfortwinz = getInnerProduct(dicount1, dicount2);
            double innerProductFor1 = getInnerProduct(dicount1, dicount1);
            double innerProductFor2 = getInnerProduct(dicount2, dicount2);
            double bast = innerProductfortwinz;
            double mqam = Math.Sqrt(innerProductFor1 * innerProductFor2);
            double distance = Math.Acos(bast / mqam);
            distance *= 180/Math.PI;
          
            return distance;
        }
    }
}