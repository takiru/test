﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//
// DataViewExtenders
//
// Extenders for WinForms controls, such as DataGridView, 
// BindingSource, BindingNavigator and so on 
//
// Author: Radu Martin (CanadianBeaver)
// Email: radu.martin@hotmail.com
// GitHub: https://github.com/CanadianBeaver/DataViewExtenders
// 

namespace CBComponents
{
    using WinForm.UI.DataDescriptors;
    using WinForm.UI.Extenders;
    using WinForm.UI.Forms;

    public static partial class FlowLayoutPanelExtenders
  {
    /// <summary>
    /// Group generator that works on group and field data descriptions (GroupDataDescriptor & FieldDataDescriptor)
    /// </summary>
    /// <param name="dataPanel">FlowLayoutPanel</param>
    /// <param name="DataSource">Data Source to support data-binding</param>
    /// <param name="Fields">Field data descriptors</param>
    public static void GenerateGroups(this FlowLayoutPanel groupPanel, object DataSource, params GroupDataDescriptor[] Groups)
    {
      FlowLayoutPanelExtenders.GenerateGroups(groupPanel, null, DataSource, Groups);
    }

    /// <summary>
    /// Group generator that works on group and field data descriptions (GroupDataDescriptor & FieldDataDescriptor)
    /// </summary>
    /// <param name="groupPanel">FlowLayoutPanel</param>
    /// <param name="toolTip">ToolTip</param>
    /// <param name="DataSource">Data Source to support data-binding</param>
    /// <param name="Groups">Group data descriptors and Field data descriptors</param>
    public static void GenerateGroups(this FlowLayoutPanel groupPanel, ToolTip toolTip, object DataSource, params GroupDataDescriptor[] Groups)
    {
      groupPanel.SuspendLayout();
      groupPanel.Controls.Clear();
      if (DataSource == null || Groups == null || Groups.Length == 0) return;
      foreach (var group in Groups)
      {
        var dataPanel = new HeaderTableLayoutPanel(); // TableLayoutPanel();
        group.GeneratedPanel = dataPanel;
        dataPanel.CaptionText = group.CaptionText;
        dataPanel.CaptionStyle = Settings.HeaderTableLayoutPanel.CaptionStyle;
        dataPanel.CaptionLineWidth = Settings.HeaderTableLayoutPanel.CaptionLineWidth;
        dataPanel.GenerateFields(toolTip, DataSource, group.Fields);
        groupPanel.Controls.Add(dataPanel);
      }
      groupPanel.ResumeLayout(false);
    }
  }
}
