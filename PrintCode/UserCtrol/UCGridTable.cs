﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace PrintCode.UserCtrol
{
    [ToolboxItem(false)]
    public partial class UCGridTable : UserControl
    {
        public UCGridTable()
        {
            InitializeComponent();
        }

         private void UCGridTable_Load(object sender, EventArgs e)
        {
            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 40, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 30, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 30, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 30, WidthType = SizeType.Percent, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 30, WidthType = SizeType.Percent, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;
            List<object> lstSource = new List<object>();
            for (int i = 0; i < 50; i++)
            {
                TestGridModel model = new TestGridModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSource.Add(model);
            }

            var page = new UCPagerControl2();
            page.DataSource = lstSource;
            this.ucDataGridView1.Page = page;
            this.ucDataGridView1.First();
        }

        private void ucDataGridView1_SizeChanged(object sender, EventArgs e)
        {
            if (this.ucDataGridView1.Page != null)
            {
                this.ucDataGridView1.Page.PageSize = this.ucDataGridView1.ShowCount;
                this.ucDataGridView1.DataSource = this.ucDataGridView1.Page.GetCurrentSource();
            }
        }
    }

    public class TestGridModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public List<TestGridModel> Childrens { get; set; }
    }
}
