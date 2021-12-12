using DiaryApp.Context;
using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryApp
{
    public partial class MainForm : Form
    {
        EntriesDbContext db = new EntriesDbContext();
        public MainForm()
        {
            InitializeComponent();
            GetEntries();
        }

        private void GetEntries()
        {
            lstEntries.DataSource = db.Entries.OrderByDescending(x => x.Date).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstEntries.SelectedItem == null) return;
            string title = txtTitle.Text;
            string content = txtContent.Text;
            Entry entry = (Entry)lstEntries.SelectedItem;
            entry.Title = title;
            entry.Content = content;
            lstEntries.DisplayMember = "";
            lstEntries.DisplayMember = "Title";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry() { Title = "New Day", Content = "" };
            db.Entries.Add(entry);
            db.SaveChanges();
            GetEntries();
            txtTitle.Focus();
            txtTitle.SelectAll();
        }

        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {

            Entry entry = (Entry)lstEntries.SelectedItem;
            txtTitle.Text = entry.Title;
            txtContent.Text = entry.Content;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstEntries.SelectedItem == null) return;
            Entry entry = (Entry)lstEntries.SelectedItem;
            db.Entries.Remove(entry);
            db.SaveChanges();
            GetEntries();
            if (lstEntries.Items.Count == 0)
            {
                txtContent.Clear();
                txtTitle.Clear();
            }
        }
    }
}
