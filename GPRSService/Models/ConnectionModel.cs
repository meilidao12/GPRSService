using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPRSService.Models
{
    public class ConnectionModel
    {
        private string phoneNum;
        public string PhoneNum
        {
            get { return phoneNum; }
            set { this.phoneNum = value; }
        }

        private string equipmentId;
        public string EquipmentId
        {
            get { return equipmentId; }
            set { this.equipmentId = value; }
        }

        private string protocolType;
        public string ProtocolType
        {
            get { return this.protocolType; }
            set { this.protocolType = value; }
        }

        public string DataSource
        {
            get
            {
                return dataSource;
            }

            set
            {
                dataSource = value;
            }
        }

        public string CollectTime
        {
            get
            {
                return collectTime;
            }

            set
            {
                collectTime = value;
            }
        }

        private string dataSource;

        private string collectTime;
     
    }

    public enum DataSource
    {
        DataBase = 0,
        Equipment = 1
    }
}
    
