using System;

namespace Infra.DataSet
{
    public class DataSetMetaData
    {
        private int _currentAutoIncrementId;
        public int CurrentAutoIncrementId
        {
            get
            {
                return _currentAutoIncrementId;
            }

            set
            {
                if (value >= 0)
                {
                    _currentAutoIncrementId = value;
                } 
                else
                {
                    throw new Exception($"Invalid autoincrement Id : '{value}'.");
                }
            }
        }

        public DataSetMetaData()
        {

        }
    }
}
