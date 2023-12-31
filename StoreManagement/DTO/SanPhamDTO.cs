﻿namespace StoreManagement.DTO
{
    class SanPhamDTO
    {
        private byte[] anh;
        public byte[] Anh
        {
            get { return anh; }
            set { anh = value; }
        }

        private string maSanPham;
        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        private string tenSanPham;
        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }

        private string maLoai;
        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private float giaTien;
        public float GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }

        public SanPhamDTO(byte[] anh, string maSanPham, string tenSanPham, string maLoai, int soLuong, float giaTien)
        {
            this.anh = anh;
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.maLoai = maLoai;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
        }
    }
}
