﻿using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Tyle.Core;

namespace Tyle.UI
{
    public partial class AboutBox : Form
    {
        public static AboutBox AppAbout { get; protected set; }

        static AboutBox()
        {
            AppAbout = new AboutBox();
        }

        protected AboutBox()
        {
            InitializeComponent();
            InitAboutContent();
        }

        private void InitAboutContent()
        {
            // [BIB]:  https://stackoverflow.com/questions/15782857/displaying-an-icon-in-a-picturebox
            //picBrandLogo.Image = Bitmap.FromHicon(Properties.Resources.Tyle.Handle);
            //lnkBrandName.Text = AppMetaData.CompanyName;
            // [BIB]:  https://stackoverflow.com/questions/16875575/display-icon-from-the-local-resources-in-a-form-window-with-c-sharp
            //picAppLogo.Image = Properties.Resources.Tyle.ToBitmap();
            //lnkAppName.Text = AppMetaData.ApplicationName;
            //lblVersion.Text = AppMetaData.ProductVersion;
            //lblCopyright.Text = AppMetaData.CopyRight;
            //lblDescription.Text = AppMetaData.Description;
            Type t = typeof(AppMetaData);
            FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
            lsvAboutDetails.View = View.Details;
            lsvAboutDetails.Items.Clear();
            lsvAboutDetails.FullRowSelect = true;
            foreach (FieldInfo fi in fields)
            {
                var fiValue = fi.GetValue(null).ToString();
                var field = new ListViewItem(fiValue);
                field.SubItems.Add(new ListViewItem.ListViewSubItem(field, fi.Name));
                field.ToolTipText = fiValue;
                lsvAboutDetails.Items.Add(field);
            }
            lsvAboutDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
