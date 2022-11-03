using System;

namespace Infra.DataSet.MetaData
{
    internal class DataSetMetaData
    {
        private int _currentAutoIncrementId = 0;
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
