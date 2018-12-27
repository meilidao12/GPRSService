using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CommunicationServers.Sockets;
using Services;
using System.Net.Sockets;
using GPRSService.Models;
using System.Timers;
using GPRSService.CS;
using ProtocolFamily;
using CommunicationServers.Pipe;
using System.Threading;
using System.Security.Cryptography;
using ProtocolFamily.YanGang;
using Services.DataBase;
namespace GPRSService
{
    
    public partial class Service1 : ServiceBase
    {
        SocketServer SocketServer = new SocketServer();
        List<SocketClientModel> SocketClientModels = new List<SocketClientModel>();
        System.Timers.Timer SendDataToClientsTimer = new System.Timers.Timer();
        System.Timers.Timer PipeTimer = new System.Timers.Timer();
        PipeClientHelper pc = new PipeClientHelper("tianchen");
        string[] parametername = { "记录时间", "更新时间", "记录类型", "记录描述", "电话号", "瞬时流量", "累积流量", "正累积流量" };
        private string[] parametervalue = new string[8];
        Access access = new Access();
        MysqlHelper mysqlHelper = new MysqlHelper();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SimpleLogHelper.Instance.WriteLog(LogType.Info, DateTime.Now, "GPRSService服务启动");
            pc.ConnectFailEvent += Pc_ConnectFailEvent;
            IniTimer();
            Ini ini = new Ini();
            if (this.SocketServer.Listen(ini.GetPort(), ini.GetIp()))
            {
                this.SocketServer.NewConnnectionEvent += SocketServer_NewConnnectionEvent;
                this.SocketServer.NewMessage1Event += SocketServer_NewMessage1Event;
                this.SocketServer.ClientDisconnectedEvent += SocketServer_ClientDisconnectedEvent;
            }
        }

        private void SocketServer_NewConnnectionEvent(Socket socket)
        {
            SimpleLogHelper.Instance.WriteLog(LogType.Info, "新的连接请求：" + socket.Handle.ToString());
        }

        private void SocketServer_NewMessage1Event(Socket socket, string Message)
        {
            if (Message.Length == 40)
            {
                return; //length=40 表示该数据是SCL_60D的握手数据
            }
            if (Message.Length == 56) //握手数据长度  以前设置的是52
            {
                HandShake(socket, Message.Substring(8, 11));
                return;
            }
            else
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Info, string.Format("Num is {0} , Message is {1}", Message.Substring(8, 11), Message), "接收");
                SendMessageToInterface(Message);
            }
        }

        private void SocketServer_ClientDisconnectedEvent(Socket socket)
        {
            SocketClientModels.RemoveAll(m => m.Socket == socket);
        }

        private void IniTimer()
        {
            SendDataToClientsTimer.Interval = 60000;
            SendDataToClientsTimer.AutoReset = true;
            SendDataToClientsTimer.Elapsed += Timer_Elapsed;
            SendDataToClientsTimer.Enabled = true;
            //---
            this.PipeTimer.Interval = 1000;
            this.PipeTimer.AutoReset = true;
            this.PipeTimer.Elapsed += PipeTimer_Elapsed;
            this.PipeTimer.Enabled = true;
        }

        private void PipeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.PipeTimer.Enabled = false;
            //SimpleLogHelper.Instance.WriteLog(LogType.Info, "正在连接管道服务器");
            pc.Run();
        }

        /// <summary>
        /// 连接客户端管道失败
        /// </summary>
        private void Pc_ConnectFailEvent()
        {
            this.PipeTimer.Enabled = true;
        }

        /// <summary>
        /// 定时发送数据到客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var socketClientModels = SocketClientModels;
            access.Refresh();
            ReadFromDataBase();
            try
            {
                //---------------------------------------------------------------------------------------------------------------
                if (socketClientModels.Count == 0) return;
                foreach (var item in socketClientModels)
                {
                    var protocolName = access.AnalysisPhoneBelongWitchProtocol(item.PhoneNum);
                    if (protocolName != ProtocolFactory.ProtocolName.NoFind)
                    {
                        var protocol = ProtocolFactory.CreateGPRSProtocol(protocolName);
                        //SimpleLogHelper.Instance.WriteLog(LogType.Info, string.Format("Num is {0} , Message is {1}",item.PhoneNum, protocol.ComposeSendData(item.PhoneNum)), "发送");
                        this.SocketServer.Send(item.Socket, this.SocketServer.HexConvertToByte(protocol.ComposeSendData(item.PhoneNum)));
                        Thread.Sleep(20);
                    }
                }
            }
            catch(Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Info, ex);
            }
            SystemHelper.ClearMemory();
        }

        private void ReadFromDataBase()
        {
            try
            {
                mysqlHelper.Open();
                SimpleLogHelper.Instance.WriteLog(LogType.Info, "连接数据库" + mysqlHelper.TestConn.ToString());
                if (mysqlHelper.TestConn)
                {
                    GetDataFormMySql();
                }
                mysqlHelper.Close();
            }
            catch(Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Info, ex);
            }
        }

        /// <summary>
        /// 从mysql数据库获取数据 并发送到界面与sqlserver数据库
        /// </summary>
        /// <param name="PhoneNum"></param>
        public void GetDataFormMySql()
        {
            try
            {
                string sql = string.Format("SELECT * FROM t_housedetaild ORDER BY  HDD_ID  DESC LIMIT 5000");
                List<t_housedetaildModel> models = mysqlHelper.GetDataTable<t_housedetaildModel>(sql);
                SimpleLogHelper.Instance.WriteLog(LogType.Info, "检索数据量为: " + models.Count);
                foreach (var item in access.ConnectionModels)
                {
                    if (item.DataSource == DataSource.DataBase.ToString())
                    {
                        if(models.Where(m => m.HDD_SIM == item.PhoneNum).ToList().Count != 0)
                        {
                            t_housedetaildModel model = models.Where(m => m.HDD_SIM == item.PhoneNum).FirstOrDefault();
                            //SimpleLogHelper.Instance.WriteLog(LogType.Info,model.HDD_SIM + "   " + model.HDD_CollectTime);
                            AnalysisDataModel an = model.AnalysisReceiveData();
                            //SimpleLogHelper.Instance.WriteLog(LogType.Info, "发送数据" + model.HDD_SIM);
                            pc.SendMessage(an.Data0);
                            if (item.CollectTime == null || model.HDD_CollectTime != DateTime.Parse(item.CollectTime)) 
                            {
                                access.UpDateRecord(model.HDD_SIM, model.HDD_CollectTime);
                                if (an.Result == AnalysisDataModel.AnalysisResult.OK)
                                {
                                    Send(an);
                                }
                            }
                        }
                        else
                        {
                            //SimpleLogHelper.Instance.WriteLog(LogType.Info,  item.PhoneNum + " 数据为空");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Info, ex);
            }
        }


        /// <summary>
        /// 握手
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="PhoneNum"></param>
        private void HandShake(Socket socket,string PhoneNum)
        {
            SimpleLogHelper.Instance.WriteLog(LogType.Info, string.Format("Socket is {0} , PhoneNum is {1}", socket.Handle.ToString(), PhoneNum), "握手");
            if(SocketClientModels.Where(m => m.PhoneNum == PhoneNum || m.Socket == socket).ToList().Count >= 1 )
            {
                SocketClientModels.RemoveAll(m => m.PhoneNum == PhoneNum);
            }
            SocketClientModels.Add(new SocketClientModel { Socket = socket, PhoneNum = PhoneNum });
        }

        /// <summary>
        /// 将数据发送到显示界面客户端
        /// </summary>
        private void SendMessageToInterface(string Data)
        {
            //发送数据
            AnalysisDataModel analysisDataModel = AnalysisData(Data);
            if (analysisDataModel.Result == AnalysisDataModel.AnalysisResult.OK)
            {
                pc.SendMessage(analysisDataModel.Data0);
                Send(analysisDataModel);
            }
        }

        /// <summary>
        /// 解析新到的数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private AnalysisDataModel AnalysisData(string Data)
        {
            string PhoneNum = Data.Substring(8, 11);
            var protocolName = access.AnalysisPhoneBelongWitchProtocol(PhoneNum);
            if (protocolName != ProtocolFactory.ProtocolName.NoFind)
            {
                var protocol = ProtocolFactory.CreateGPRSProtocol(protocolName);
                return protocol.AnalysisReceiveData(Data);
            }
            else
            {
                return new AnalysisDataModel() { Result = AnalysisDataModel.AnalysisResult.ERR };
            }
        }

        protected override void OnStop()
        {
            SimpleLogHelper.Instance.WriteLog(LogType.Info, DateTime.Now, "GPRSService服务结束");
        }

        /// <summary>
        /// 发送到数据库 
        /// 添加服务饮用： http://211.143.68.36:8000/WebService.asmx 
        /// </summary>
        /// <param name="Data"></param>
        public void Send(AnalysisDataModel Data)
        {
            AnalysisData(Data);
            Thread td = new Thread(SendData);
            td.Start();
        }

        private void SendData()
        {
            try
            {
                ServiceReference1.WebServiceSoapClient ws = new ServiceReference1.WebServiceSoapClient();
                string tableName = "yg_" + parametervalue[4].ToString();
                int tableIndex = int.Parse(access.ConnectionModels.Where(m => m.PhoneNum == parametervalue[4].ToString()).FirstOrDefault().EquipmentId);
                string[] TableArray = new string[] { tableName };
                List<ServiceReference1.SqlParameter[]> parameters = new List<ServiceReference1.SqlParameter[]>();
                List<ServiceReference1.SqlParameter> plist = new List<ServiceReference1.SqlParameter>();
                for (int i = 0; i <= 7; i++)
                {
                    var parameter = new ServiceReference1.SqlParameter();
                    parameter.ParameterName = parametername[i];
                    parameter.Value = parametervalue[i];
                    plist.Add(parameter);
                }
                parameters.Add(plist.ToArray());
                string password = Encrypt(Encrypt("test"));
                string a = ws.SaveDataV4("yangang", password, tableIndex, TableArray, parameters.ToArray());
            }
            catch(Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Error, ex);
            }
        }

        private void AnalysisData(AnalysisDataModel Data)
        {
            AnalysisDataHelper analysisDataHelper = new AnalysisDataHelper();
            TimeFormatHelper timeHelper = new TimeFormatHelper();
            var model = analysisDataHelper.AnalysisData(Data.Data0);
            parametervalue[0] = timeHelper.HexTimeToDecTime(model.Data3); //加一个转化
            parametervalue[1] = timeHelper.HexTimeToDecTime(model.Data3);
            parametervalue[2] = "历史记录";
            parametervalue[3] = "定期保存";
            parametervalue[4] = model.Data0; //电话号
            parametervalue[5] = model.Data1; //瞬时流量
            parametervalue[6] = model.Data2; //累积流量
            parametervalue[7] = ""; //正累积流量
            //SimpleLogHelper.Instance.WriteLog(LogType.Info, string.Format("{0}  {1}  {2}  {3}", model.Data3, model.Data0, model.Data1, model.Data2));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public string Encrypt(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列 
            byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值 
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }
    }
}
/*
 * 服务器IP： 211.143.68.36 
 */