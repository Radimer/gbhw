using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace task4
{
    public class Calendar
    {
        #region Поля

        public string fileName;
        private List<Date> list;

        #endregion

        #region Свойства

        public int Count
        {
            get { return list.Count; }
        }

        public Date this[int index]
        {
            get { return list[index]; }
        }

        #endregion

        #region Конструкторы

        public Calendar(string fileName)
        {
            this.fileName = fileName;
            list = new List<Date>();
        }

        #endregion

        #region Публичные методы

        public void Add(string text, string Birth)
        {
            list.Add(new Date(text, Birth));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Date>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Date>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Date>));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }

        #endregion

    }
}
