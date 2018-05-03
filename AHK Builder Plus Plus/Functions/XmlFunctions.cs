using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHK_Builder_Plus_Plus.Functions
{
    internal class XmlFunctions
    {
        private DataSet ahkDataSet;

        public XmlFunctions(DataSet ahkDataSet)
        {
            this.ahkDataSet = ahkDataSet;
        }

        internal bool Load(string fileLocation = null)
        {
            if (string.IsNullOrEmpty(fileLocation))
                fileLocation = Path.Combine(Environment.CurrentDirectory, $"tmp_backup.xml");

            if (!File.Exists(fileLocation))
                return false;

            try
            {
                ahkDataSet.Clear();
                ahkDataSet.ReadXml(fileLocation);
            }
            catch
            {
                return false;
            }

            return true;
        }

        internal bool Save(string fileLocation = null)
        {
            if (string.IsNullOrEmpty(fileLocation))
                fileLocation = Path.Combine(Environment.CurrentDirectory, $"tmp_backup.xml");

            try
            {
                ahkDataSet.WriteXml(fileLocation);
            }
            catch
            {
                return false;
            }

            return true;
        }

        internal void ClearBackup()
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, $"tmp_backup.xml");

            try
            {
                if (File.Exists(fileLocation))
                    File.Delete(fileLocation);
            }
            catch { }
        }
    }
}
