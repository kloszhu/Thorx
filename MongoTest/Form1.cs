using MongoTest.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thorx.MongoResponsitory;
using Thorx.MongoToolkit;
namespace MongoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Door door = new Door();
            door.Code = 1;
            door.Name = "门1";
            AbstractResponsitory<Door>.Responsitory.Insert(door);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           var count= AbstractResponsitory<Door>.Responsitory.GetAll().Count();
            MessageBox.Show(count.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            City city = new City();
            city.Create();
            city.name = "长沙";
            city.num = "changsha";
            city.WhitchDoor.Create();
            city.WhitchDoor.Name = "喜盈门范城";
            city.WhitchDoor.Code =2;
            new ToolkitResponsitory<City>().Repository.Insert(city);
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            var count = new ToolkitResponsitory<City>().Repository.FindAll(a=>a.WhitchDoor.Id==new Guid( "6390e2fe-f028-44b0-827c-2e7ed3e40852")).Count();
            MessageBox.Show(count.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var count = new ToolkitResponsitory<City>().Repository.Find(a => a.WhitchDoor.Id ==new Guid( "6390e2fe-f028-44b0-827c-2e7ed3e40852"));
            count.WhitchDoor.Name = "旷真";
            new ToolkitResponsitory<City>().Repository.Update(count);
            MessageBox.Show(count.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private TimeCost TimeCostTest(Action action) {
            TimeCost cost = new TimeCost();
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // 开始监视代码运行时间

            stopwatch.Stop(); // 停止监视
            TimeSpan timespan = stopwatch.Elapsed; // 获取当前实例测量得出的总时间
            cost.Hours = timespan.TotalHours.ToString("#0.00000000 "); // 总小时
            cost.Minutes = timespan.TotalMinutes.ToString("#0.00000000 "); // 总分钟
            cost.Seconds = timespan.TotalSeconds.ToString("#0.00000000 "); // 总秒数
            cost.Milliseconds = timespan.TotalMilliseconds.ToString("#0.00000000 "); // 总毫秒数
            return cost;
        }
        class TimeCost {
            public string Hours { get; set; }
            public string Minutes { get; set; }
            public string Seconds { get; set; }
            public string Milliseconds { get; set; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Piano piano = new Piano();
            piano.Name = "菊花台";
            piano.Player = "周杰伦";
            new ToolkitResponsitory<Piano,Guid?>().Repository.Insert(piano);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Piano piano = new Piano();
            piano.Name = "菊花台1";
            piano.Player = "周杰伦";
          var data=   new ToolkitResponsitory<Piano, Guid?>().Repository.Insert(piano);
            List<Piano> pianos = new List<Piano>();
            var time1= TimeCostTest(() => {
                pianos = GetPianos();
            });
            richTextBox1.Text += time1.Seconds+"\n";
            MessageBox.Show("11");
        }

        private List<Piano> GetPianos() {
            List<Piano> pianos = new List<Piano>();
            for (int i = 0; i < 100000; i++)
            {
                Piano p = new Piano();
                p.Name = "菊花台" + i.ToString();
                p.Player = "周杰伦";
                pianos.Add(p);
            }
            return pianos;
        }
    }
}
