using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace GPRSService.Models
{
    class SocketClientModel
    {
        public Socket Socket { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 瞬时流量
        /// </summary>
        public string HourlyFlowRates { get; set; } 
        /// <summary>
        /// 累积量
        /// </summary>
        public string TotalFlow { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Socket连接状态
        /// </summary>
        public SocketState SocketState { get; set; }
    }

    public enum SocketState
    {
        Connneted = 0,
        Closed = 1
    }
}
