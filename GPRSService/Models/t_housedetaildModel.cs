using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolFamily;
using Services;

namespace GPRSService.Models
{
    public class t_housedetaildModel 
    {
        
        public string HDD_SIM
        {
            get
            {
                return hDD_SIM;
            }

            set
            {
                hDD_SIM = value;
            }
        }

        public decimal HDD_InstantFlux
        {
            get
            {
                return hDD_InstantFlux;
            }

            set
            {
                hDD_InstantFlux = value;
            }
        }

        public decimal HDD_CumFlux
        {
            get
            {
                return hDD_CumFlux;
            }

            set
            {
                hDD_CumFlux = value;
            }
        }

        public DateTime HDD_CollectTime
        {
            get
            {
                return hDD_CollectTime;
            }

            set
            {
                hDD_CollectTime = value;
            }
        }

        private DateTime hDD_CollectTime;

        private decimal hDD_CumFlux;

        private decimal  hDD_InstantFlux;

        private string hDD_SIM;


        public  AnalysisDataModel AnalysisReceiveData()
        {
            string result;
            try
            {
                //---电话号码
                string phoneNum = HDD_SIM;
                //---瞬时流量
                string HourlyFlowRates = MathHelper.DoubleToHex(HDD_InstantFlux.ToString());
                //---累积流量
                string TotalFlow = MathHelper.DoubleToHex(HDD_CumFlux.ToString());
                TimeFormatHelper timeHelper = new TimeFormatHelper();
                result = phoneNum + HourlyFlowRates + TotalFlow + timeHelper.GetDateTime(HDD_CollectTime);
                //CRC校验
                result += CRC.ToModbusCRC16(result);
            }
            catch (Exception ex)
            {
                SimpleLogHelper.Instance.WriteLog(LogType.Error, ex, "AutecAory5000错误");
                result = "Err";
            }
            AnalysisDataModel an = new AnalysisDataModel();
            an.Data0 = result;
            an.Result = AnalysisDataModel.AnalysisResult.OK;
            return an;
        }

    }
}
