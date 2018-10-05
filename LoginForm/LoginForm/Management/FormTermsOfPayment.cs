using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.ManagementModule
{
    public partial class FormTermsOfPayment : MyForm
    {

        PaymentTerm selectedTerm;
        bool editMode = false;

        public FormTermsOfPayment()
        {
            InitializeComponent();
        }

        private void FormTermsOfPayment_Load(object sender, EventArgs e)
        {
            populateListBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            DateTime currentDate = Utils.GetCurrentDateTime();

            if (!editMode)
            {
                PaymentTerm term = new PaymentTerm();
                TimeSpan ts = new TimeSpan();

                try
                {
                    switch (cbType.Text)
                    {
                        case "Days":
                            ts = currentDate.AddDays(int.Parse(cbCount.Text)) - currentDate;
                            break;
                        case "Weeks":
                            ts = currentDate.AddDays(int.Parse(cbCount.Text) * 7) - currentDate;
                            break;
                        case "Months":
                            ts = currentDate.AddMonths(int.Parse(cbCount.Text)) - currentDate;
                            break;
                    }

                    term.timespan = Convert.ToInt32(ts.TotalSeconds);
                    term.term_name = txtNote.Text;

                    IME.PaymentTerms.Add(term);
                    IME.SaveChanges();
                    Utils.LogKayit("TermsOfPayment", "TermsOfPayment added");
                    changeMode(false);

                    populateListBox();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("ToP2:Count must be an integer number.");
                }
            }
            else
            {
                PaymentTerm term = IME.PaymentTerms.Where(t => t.ID == selectedTerm.ID).FirstOrDefault();
                TimeSpan ts = new TimeSpan();

                try
                {
                    switch (cbType.Text)
                    {
                        case "Days":
                            ts = currentDate.AddDays(int.Parse(cbCount.Text)) - currentDate;
                            break;
                        case "Weeks":
                            ts = currentDate.AddDays(int.Parse(cbCount.Text) * 7) - currentDate;
                            break;
                        case "Months":
                            ts = currentDate.AddMonths(int.Parse(cbCount.Text)) - currentDate;
                            break;
                    }

                    term.timespan = Convert.ToInt32(ts.TotalSeconds);
                    term.term_name = txtNote.Text;

                    IME.SaveChanges();
                    Utils.LogKayit("TermsOfPayment", "TermsOfPayment updated");
                    changeMode(false);

                    populateListBox();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("ToP3:Count must be an integer number.");
                }
                editMode = false;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            changeMode(true);
            cbCount.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            txtNote.Text = String.Empty;

        }

        private void changeMode(bool isOpen)
        {

            lbPaymentList.Enabled = !isOpen;
            txtNote.ReadOnly = !isOpen;
            btnNew.Enabled = !isOpen;
            btnEdit.Enabled = !isOpen;
            btnDelete.Enabled = !isOpen;

            cbCount.Enabled = isOpen;
            cbType.Enabled = isOpen;
            btnSave.Enabled = isOpen;
            btnCancel.Enabled = isOpen;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            changeMode(true);
            editMode = true;
        }

        private void lbPaymentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTerm = (PaymentTerm)lbPaymentList.SelectedItem;
            populateForm(selectedTerm);
        }

        private void populateForm(PaymentTerm term)
        {
            TimeSpan span = new TimeSpan(term.timespan * 100);
            int days = Convert.ToInt32(span.TotalDays * 100000);
            txtNote.Text = term.term_name;

            cbCount.Text = days.ToString();
            cbType.Text = "Days";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            editMode = false;
            changeMode(false);
            lbPaymentList.SelectedItem = selectedTerm;
            populateForm(selectedTerm);
        }

        private void populateListBox()
        {
            lbPaymentList.DataSource = new IMEEntities().PaymentTerms.OrderBy(p => p.OrderNo).ToList();
            lbPaymentList.DisplayMember = "term_name";
            lbPaymentList.ValueMember = "ID";

            cbCount.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            lbPaymentList.DataSource = new IMEEntities().PaymentTerms.OrderBy(p => p.timespan).ToList();
            lbPaymentList.DisplayMember = "term_name";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Selected term will be deleted! Do you confirm?", " Delete", MessageBoxButtons.OKCancel);

            if (/*result == DialogResult.OK*/Messages.DeleteMessage())
            {
                try
                {
                    IMEEntities IME = new IMEEntities();
                    PaymentTerm term = IME.PaymentTerms.Where(t => t.ID == selectedTerm.ID).First();
                    IME.PaymentTerms.Remove(term);
                    IME.SaveChanges();
                    Utils.LogKayit("TermsOfPayment", "TermsOfPayment deleted");
                    populateListBox();
                }
                catch (Exception ex)
                {
                    Messages.ErrorMessage("ToP1: There was an error while deleting the data. Try later.");
                    throw;
                }
            }
        }

        private void lbPaymentList_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lbPaymentList.SelectedItem == null) return;
            this.lbPaymentList.DoDragDrop(this.lbPaymentList.SelectedItem, DragDropEffects.Move);
        }

        private void lbPaymentList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbPaymentList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbPaymentList.PointToClient(new Point(e.X, e.Y));
            int index = this.lbPaymentList.IndexFromPoint(point);
            if (index < 0) index = this.lbPaymentList.Items.Count-1;
            object data = e.Data.GetData(typeof(DateTime));
            this.lbPaymentList.Items.Remove(data);
            this.lbPaymentList.Items.Insert(index, data);
        }
    }
}
