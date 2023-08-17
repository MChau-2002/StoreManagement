﻿using StoreManagement.BUS;
using StoreManagement.DAO;
using StoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManagement
{
    public partial class FormDSKhachHang : Form
    {
        KhachHangDTO KH;
        string maKH;
        public FormDSKhachHang()
        {
            InitializeComponent();
        }

        private void FormDSKhachHang_Load(object sender, EventArgs e)
        {
            dgvKH.DataSource = KhachHangDAO.Instance.DSKhachHang();
            dgvKH.Columns["Mã khách hàng"].ReadOnly = true;

            if (this.TopLevel == false)
            {
                btnChonKH.Enabled = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKH = tbxTimKiem.Text;
            KhachHangBUS.Instance.TimKiemKH(dgvKH, tenKH);
        }

        private void GetValue()
        {
            if (dgvKH.SelectedCells[0].OwningRow.Cells["Mã khách hàng"].Value != null)
            {
                string maKH = dgvKH.SelectedCells[0].OwningRow.Cells["Mã khách hàng"].Value.ToString();
                string tenKH = dgvKH.SelectedCells[0].OwningRow.Cells["Tên khách hàng"].Value.ToString();
                string Sdt = dgvKH.SelectedCells[0].OwningRow.Cells["Số điện thoại"].Value.ToString();
                string GhiChu = dgvKH.SelectedCells[0].OwningRow.Cells["Ghi chú"].Value.ToString();

                KH = new KhachHangDTO(maKH, tenKH, Sdt, GhiChu);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemKH them = new FormThemKH();
            them.ShowDialog();
            FormDSKhachHang_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvKH.SelectedCells[0].OwningRow.Cells["Mã khách hàng"].Value.ToString();
                if (KhachHangBUS.Instance.XoaKH(id) == true)
                {
                    MessageBox.Show("Xóa thông tin thành công");
                }
                else
                {
                    MessageBox.Show("Xóa thông tin không thành công");
                }
                FormDSKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                GetValue();
                if (KH != null)
                {
                    if (KhachHangBUS.Instance.SuaKH(KH) == true)
                    {
                        MessageBox.Show("Sửa thông tin thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mời chọn khách hàng");
                }
                FormDSKhachHang_Load(sender, e);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormDSKhachHang_Load(sender, e);
        }

        public string chonKH()
        {
            return maKH;
        }

        private void btnChonKH_Click(object sender, EventArgs e)
        {
            maKH = dgvKH.SelectedCells[0].OwningRow.Cells["Mã khách hàng"].Value.ToString();
            this.Close();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            FormDSKhachHang_Load(sender, e);
        }
    }
}
