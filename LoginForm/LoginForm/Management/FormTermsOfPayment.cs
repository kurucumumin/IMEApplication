using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.ManagementModule
{
    public partial class FormTermsOfPayment : Form
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


            if (!editMode)
            {
                PaymentTerm term = new PaymentTerm();
                TimeSpan ts = new TimeSpan();

                try
                {
                    switch (cbType.Text)
                    {
                        case "Days":
                            ts = DateTime.Now.AddDays(int.Parse(cbCount.Text)) - DateTime.Now;
                            break;
                        case "Weeks":
                            ts = DateTime.Now.AddDays(int.Parse(cbCount.Text) * 7) - DateTime.Now;
                            break;
                        case "Months":
                            ts = DateTime.Now.AddMonths(int.Parse(cbCount.Text)) - DateTime.Now;
                            break;
                    }

                    term.timespan = Convert.ToInt32(ts.TotalSeconds);
                    term.term_name = cbCount.Text + " " + cbType.Text + " " + txtNote.Text;

                    IME.PaymentTerms.Add(term);
                    IME.SaveChanges();

                    changeMode(false);

                    populateListBox();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Count must be an integer number.");
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
                            ts = DateTime.Now.AddDays(int.Parse(cbCount.Text)) - DateTime.Now;
                            break;
                        case "Weeks":
                            ts = DateTime.Now.AddDays(int.Parse(cbCount.Text) * 7) - DateTime.Now;
                            break;
                        case "Months":
                            ts = DateTime.Now.AddMonths(int.Parse(cbCount.Text)) - DateTime.Now;
                            break;
                    }

                    term.timespan = Convert.ToInt32(ts.TotalSeconds);
                    term.term_name = cbCount.Text + " " + cbType.Text + " " + txtNote.Text;
                    
                    IME.SaveChanges();

                    changeMode(false);

                    populateListBox();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Count must be an integer number.");
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
            string[] tokens = term.term_name.Split(new char[] { ' ' }, 3);


            cbCount.Text = tokens[0];
            cbType.SelectedItem = tokens[1];

            if (tokens.Count() == 3)
            {
                txtNote.Text = tokens[2];
            }
            else
            {
                txtNote.Text = String.Empty;
            }
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
            cbCount.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            lbPaymentList.DataSource = new IMEEntities().PaymentTerms.OrderBy(p => p.timespan).ToList();
            lbPaymentList.DisplayMember = "term_name";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Selected term will be deleted! Do you confirm?", " Delete", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                IMEEntities IME = new IMEEntities();
                PaymentTerm term = IME.PaymentTerms.Where(t => t.ID == selectedTerm.ID).First();
                IME.PaymentTerms.Remove(term);
                IME.SaveChanges();

                populateListBox();
            }
        }
    }
}
