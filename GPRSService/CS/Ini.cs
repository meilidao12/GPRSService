using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using ProtocolFamily;
namespace GPRSService.CS
{
    public class Ini  
    {
        IniHelper IniHelper = new IniHelper(System.AppDomain.CurrentDomain.BaseDirectory + @"Set.ini");
        List<string> AutecAory5000Phones = new List<string>();
        List<string> AutecNewModbusRtuPhones = new List<string>();
        List<string> AutecOldModbusRtuPhones = new List<string>();
        List<string> HuiZhongSCL_61DPhones = new List<string>();
        public Ini()
        {
            this.AutecAory5000Phones = this.IniHelper.ReadIni("Protocols", "AutecAory5000").Split(',').ToList();
            this.AutecNewModbusRtuPhones = this.IniHelper.ReadIni("Protocols", "AutecNewModbusRtu").Split(',').ToList();
            this.AutecOldModbusRtuPhones = this.IniHelper.ReadIni("Protocols", "AutecOldModbusRtu").Split(',').ToList();
            this.HuiZhongSCL_61DPhones = this.IniHelper.ReadIni("Protocols", "HuiZhongSCL_61D").Split(',').ToList();
        }
        public ProtocolFactory.ProtocolName AnalysisPhoneBelongWitchProtocol(string PhoneNum)
        {
            if(this.AutecAory5000Phones.Exists(m => m == PhoneNum))
            {
                return ProtocolFactory.ProtocolName.AutecAory5000;
            }
            else if(this.AutecNewModbusRtuPhones.Exists(m => m == PhoneNum))
            {
                return ProtocolFactory.ProtocolName.AutecNewModbusRtu;
            }
            else if(this.AutecOldModbusRtuPhones.Exists(m => m == PhoneNum))
            {
                return ProtocolFactory.ProtocolName.AutecOldModbusRtu;
            }
            else if (this.HuiZhongSCL_61DPhones.Exists(m => m == PhoneNum))
            {
                return ProtocolFactory.ProtocolName.HuiZhongSCL_61D;
            }
            else
            {
                return ProtocolFactory.ProtocolName.NoFind;
            }
        }

        public string GetPort()
        {
            string port = this.IniHelper.ReadIni("Socket", "Port");
            if(string.IsNullOrEmpty(port))
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Error, "端口号不能为空");
                return "";
            }
            return port;
        }

        public String GetIp()
        {
            string ip = this.IniHelper.ReadIni("Socket", "IP");
            if (string.IsNullOrEmpty(ip)) return "";
            List<string> Nums =  ip.Split('.').ToList();
            foreach(var num in Nums)
            {
                if (int.Parse(num) > 255)
                {
                    return "";
                }
            }
            return ip;
        }
    }
}
