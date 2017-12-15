using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.DataSet;
namespace LoginForm
{
    public partial class frmArea : Form
    {
        #region Public Variables

        IMEEntities IME = new IMEEntities();
        int inNarrationCount = 0;
        int dgvcell = 0;
        //frmRoute frmRouteObj;
        //frmCustomer frmCustomerobj;
        //frmSupplier frmSupplierobj;
        decimal decAreaId;
        decimal decIdForOtherForms = 0;
        #endregion
        #region Functions

        public frmArea()
        {
            InitializeComponent();
        }

        public void AreaGridfill()
        {
                dgvArea.DataSource = IME.Areas.ToList();
        }

        public void RouteNACreateUnderTheArea()
        {
            Route r = new Route();
            r.routeName = "NA";
            r.areaId= decAreaId;
            r.narration = txtNarration.Text.Trim();
            IME.Routes.Add(r);
            IME.SaveChanges();            
        }

        public void SaveOrEdit()
        {
            try
            {
                if (txtAreaName.Text.Trim() == string.Empty)
                {

                    MessageBox.Show("Enter area name");
                    txtAreaName.Focus();
                }
                else
                {
                    if (btnSave.Text == "Save")
                    {
                        if (IME.Areas.Where(a => a.areaName == txtAreaName.Text.Trim()).FirstOrDefault() == null)
                        {
                            Area area = new Area();
                            area.areaName = txtAreaName.Text.Trim();
                            area.narration = txtNarration.Text.Trim();
                            area.areaId = decAreaId;
                            IME.Areas.Add(area);
                            IME.SaveChanges();

                        }
                        else
                        {
                            MessageBox.Show("Area name already exist");
                            txtAreaName.Focus();
                        }
                    }


                    else
                    {

                        DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to update?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                        
                        if (IME.Areas.Where(a => a.areaId == decAreaId).Where(b => b.areaName == txtAreaName.Text.Trim()).FirstOrDefault() == null)
                            {
                                Area area = IME.Areas.Where(a => a.areaId == decAreaId).FirstOrDefault();
                                area.areaName = txtAreaName.Text.Trim();
                                area.narration = txtNarration.Text.Trim();
                                area.areaId = decAreaId;
                                IME.SaveChanges();
                                    AreaGridfill();
                                MessageBox.Show("Area updated successfully");
                                    Clear();
                            }
                            else
                            {
                                MessageBox.Show("Area name already exist");
                                txtAreaName.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Delete()
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();

               
                    try
                    {
                        IME.Areas.Remove(IME.Areas.Where(a => a.areaId == decAreaId).FirstOrDefault());
                    }
                    catch
                    {
                    MessageBox.Show("Area deleted successfully");
                        Clear();
                    }
                
            }
           
        }


        public void Clear()
        {
                txtAreaName.Text = string.Empty;
                txtNarration.Text = string.Empty;
                txtAreaName.Focus();
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                AreaGridfill();
            
        }


        //public void CallFromRoute(frmRoute frmRoute)
        //{
        //    try
        //    {
        //        this.frmRouteObj = frmRoute;
        //        dgvArea.Enabled = false;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AR6" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        //public void CallFromCustomer(frmCustomer frmCustomer)
        //{
        //    try
        //    {
        //        dgvArea.Enabled = false;
        //        btnDelete.Enabled = false;
        //        this.frmCustomerobj = frmCustomer;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AR7" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        //public void CallFromSupplier(frmSupplier frmSupplier)
        //{
        //    try
        //    {
        //        dgvArea.Enabled = false;
        //        this.frmSupplierobj = frmSupplier;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AR8" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        #endregion
        #region Events

        private void btnFrmClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
                Clear();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
                    SaveOrEdit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
                Clear();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Delete();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
                    this.Close();

        }


        private void frmArea_FormClosing(object sender, FormClosingEventArgs e)
        {
                //if (frmCustomerobj != null)
                //{
                //    frmCustomerobj.ReturnFromAreaForm(decIdForOtherForms);
                //}
                //if (frmRouteObj != null)
                //{
                //    frmRouteObj.ReturnFromAreaForm(decIdForOtherForms);
                //    frmRouteObj.Enabled = true;
                //}
                //if (frmSupplierobj != null)
                //{
                //    frmSupplierobj.ReturnFromAreaForm(decIdForOtherForms);
                //}

        }


        private void dgvArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex != -1)
                {
                    string strArea = dgvArea.CurrentRow.Cells["dgvtxtarea"].Value.ToString();
                    if (strArea != "NA")
                    {
                    decimal areaID = Convert.ToDecimal(dgvArea.CurrentRow.Cells["areaId"].Value.ToString());
                    Area area = IME.Areas.Where(a => a.areaId == areaID).FirstOrDefault();
                        txtAreaName.Text = area.areaName;
                        txtNarration.Text = area.narration;
                        btnSave.Text = "Update";
                        btnDelete.Enabled = true;
                        txtAreaName.Focus();
                        decAreaId = Convert.ToDecimal(dgvArea.CurrentRow.Cells["areaId"].Value.ToString());
                    }
                    else
                    {
                    MessageBox.Show("NA Area cannot update or delete");
                        Clear();
                    }
                }
        }


        private void dgvArea_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvArea.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// for enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        btnSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR18" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Length;
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR19" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR20" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        txtAreaName.Focus();
                        txtAreaName.SelectionStart = 0;
                        txtAreaName.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR21" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmArea_KeyDown(object sender, KeyEventArgs e)
        {
                //if (e.KeyCode == Keys.Escape)
                //{
                //    if (PublicVariables.isMessageClose)
                //    {
                //        Messages.CloseMessage(this);
                //    }
                //    else
                //    {
                //        this.Close();
                //    }
                //}
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {
                    btnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
                {
                    if (btnDelete.Enabled == true)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
        }

        private void dgvArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvArea.CurrentCell == dgvArea[dgvArea.Columns.Count - 1, dgvArea.Rows.Count - 1])
                    {
                        if (dgvcell == 1)
                        {
                            dgvcell = 0;
                            btnClose.Focus();
                            dgvArea.ClearSelection();
                            e.Handled = true;
                        }
                        else
                        {
                            dgvcell++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR23" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// grid area keyup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArea_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (dgvArea.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvArea.CurrentCell.ColumnIndex, dgvArea.CurrentCell.RowIndex);
                        dgvArea_CellDoubleClick(sender, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AR24" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
