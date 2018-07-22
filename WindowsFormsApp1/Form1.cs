using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static ApiResult result;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "https://api.bitbucket.org/2.0/repositories";
            result = _downloadSerializedData<ApiResult>(s);
            string msg = "";
            foreach(Value x in result.values)
            {
                msg = msg + x.Name + "\n";
            }
            label1.Text = msg;
        }

        private static T _downloadSerializedData<T>(string url) where T:new() {
            using(var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public class ApiResult
        {
            public List<Value> values { get; set; }
        }
        public class Value
        {
            public string Name { set; get; }
        }
    }
}
