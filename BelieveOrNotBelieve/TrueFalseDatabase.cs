using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BelieveOrNotBelieve
{
    public class TrueFalseDatabase
    {
        #region Private Fields

        private string _fileName;
        private List<Question> _questions;

        #endregion

        #region Public Properties

        public int Count => _questions.Count;
        public Question this[int index] => _questions[index];
        public string FileName
        {
            get => _fileName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) == false)
                {
                    _fileName = value;
                }
            }
        }

        #endregion

        #region Constructors

        public TrueFalseDatabase(string fileName)
        {
            FileName = fileName;
            _questions = new List<Question>();
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            _questions.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (_questions != null && index >= 0 && index < _questions.Count)
            {
                _questions.RemoveAt(index);
            }
        }

        public void Save()
        {
            if (_questions != null)
            {
                XmlSerializer xmlFormater = new XmlSerializer(typeof(List<Question>));
                FileStream fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                xmlFormater.Serialize(fileStream, _questions);
                fileStream.Close();
            }
        }

        public void Load()
        {
            if (File.Exists(FileName))
            {
                XmlSerializer xmlFormater = new XmlSerializer(typeof(List<Question>));
                FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                _questions = xmlFormater.Deserialize(fileStream) as List<Question>;
                fileStream.Close();
            }
        }

        #endregion
    }
}
