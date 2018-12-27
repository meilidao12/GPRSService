using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.DataBase;
using System.Data;
using System.Data.OleDb;
using GPRSService.Models;
using ProtocolFamily;
using System.Diagnostics;
namespace GPRSService.CS
{
    public class Access
    {
        private AccessHelper accessHelper = new AccessHelper();
        List<string> AutecAory5000Phones = new List<string>();
        List<string> AutecNewModbusRtuPhones = new List<string>();
        List<string> AutecOldModbusRtuPhones = new List<string>();
        List<string> HuiZhongSCL_61DPhones = new List<string>();
        private List<ConnectionModel> connectionModels;

        public List<ConnectionModel> ConnectionModels
        {
            get { return this.connectionModels; }
            set { connectionModels = value; }
        }

        public Access()
        {
            connectionModels = new List<ConnectionModel>();
            ConnectionModels = new List<ConnectionModel>();
            Refresh();
        }

        public void Refresh()
        {
            ConnectionModels.Clear();
            DataTable dataTable = accessHelper.GetDataTable("Select * from ConnectionSet1");
            if (dataTable == null) return;
            this.ConnectionModels = dataTable.AsEnumerable().Select(
                m => new ConnectionModel
                {
                    PhoneNum = m.Field<string>("SIM卡号"),
                    EquipmentId = m.Field<string>("EquipmentId"),
                    ProtocolType = m.Field<string>("仪表型号"),
                    DataSource = m.Field<string>("DataSource"),
                    CollectTime = m.Field<string>("CollectTime")
                }
            ).ToList();
        }

        public ProtocolFactory.ProtocolName AnalysisPhoneBelongWitchProtocol(string PhoneNum)
        {
            var model = this.ConnectionModels.Where(m => m.PhoneNum == PhoneNum).FirstOrDefault();
            if (model != null)
            {
                switch (model.ProtocolType)
                {
                    case "积算仪_AORY5000":
                        return ProtocolFactory.ProtocolName.AutecAory5000;
                    case "积算仪_新":
                        return ProtocolFactory.ProtocolName.AutecNewModbusRtu;
                    case "积算仪_老":
                        return ProtocolFactory.ProtocolName.AutecOldModbusRtu;
                    case "SCL_61D0":
                        return ProtocolFactory.ProtocolName.HuiZhongSCL_61D;
                    default:
                        return ProtocolFactory.ProtocolName.NoFind;
                }
            }
            else
            {
                return ProtocolFactory.ProtocolName.NoFind;
            }
        }

        public bool UpDateRecord(string PhoneNum , DateTime CollectTime)
        {
            bool result;
            try
            {
                string sql = string.Format("UpDate ConnectionSet1 set CollectTime='{0}' where SIM卡号='{1}';", CollectTime, PhoneNum);
                result =  accessHelper.Execute(sql);
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
