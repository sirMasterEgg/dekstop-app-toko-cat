using System;

namespace toko_cat
{
    class Barang
    {
        public int id;
        public String nama;
        public int harga;
        public int jumlah;
        public int subtotal;

        public Barang(int id, string nama, int harga, int jumlah)
        {
            this.id = id;
            this.nama = nama;
            this.harga = harga;
            this.jumlah = jumlah;
            this.subtotal = jumlah * harga;
        }

        public void updateJumlah (int jumlahBaru)
        {
            this.jumlah = jumlahBaru;
            this.subtotal = jumlahBaru * this.harga;
        }
    }
}
