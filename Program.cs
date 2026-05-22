
using System.Reflection.Metadata.Ecma335;

abstract class PesananMakanan
{
    private string namaPemesan;
    private string nomorMeja;
    private string menuUtama;
    public RiwayatPesanan riwayat = new RiwayatPesanan();
    //public RiwayatPesanan riwayat;

    //public RiwayatPesanan Riwayat
    //{
    //    get { return namaPemesan; }
    //    set { namaPemesan = NamaPemesan; }
    //}

    public string NamaPemesan
    {
        get { return namaPemesan; }
        set { namaPemesan = NamaPemesan; }
    }


    public string NomorMeja
    {
        get { return nomorMeja; }
        set { nomorMeja = NomorMeja; }
    }

    public string MenuUtama
    {
        get { return menuUtama; }
        set { menuUtama = MenuUtama; }
    }

    public PesananMakanan(string namaPemesan, string nomorMeja, string menuUtama, int jumlah)
    {
        this.namaPemesan = namaPemesan;
        this.nomorMeja = nomorMeja;
        this.menuUtama = menuUtama;
        riwayat.jumlahPorsii = jumlah;
    }
    public virtual void tampilInfo()
    {

    }

    public abstract void hitungTotalBill(int jumlahPorsi);
}


class PaketHemat : PesananMakanan
{
    private int hargaPerPorsi;

    public PaketHemat(string namaPemesan, string nomorMeja, string menuUtama, int harga, int jumlah) : base(namaPemesan, nomorMeja, menuUtama, jumlah)
    {
        hargaPerPorsi = harga;
        riwayat.kategoriPaket = "Hemat";

        //this.namaPemesan =  namaPemesan;
    }

    public override void hitungTotalBill(int jumlahPorsi)
    {
        Console.WriteLine("Total Bill : Rp " + jumlahPorsi * hargaPerPorsi);
    }

    public override void tampilInfo()
    {
        Console.WriteLine($"Pemesan : {NamaPemesan} | Meja : {NomorMeja} | Menu : {MenuUtama}");
    }
}

class PaketPrasmanan : PesananMakanan
{
    private int hargaPerPorsi;
    private int biayaService = 2000;

    public PaketPrasmanan(string namaPemesan, string nomorMeja, string menuUtama, int harga, int jumlah) : base(namaPemesan, nomorMeja, menuUtama, jumlah)
    {
        hargaPerPorsi = harga;
        riwayat.kategoriPaket = "Prasmanan";
    }

    public override void hitungTotalBill(int jumlahPorsi)
    {
        Console.WriteLine("Total Bill : Rp " + (jumlahPorsi * hargaPerPorsi + biayaService));
    }
    public override void tampilInfo()
    {
        Console.WriteLine($"Pemesan : {NamaPemesan} | Meja : {NomorMeja} | Menu : {MenuUtama}");
    }
}
class RiwayatPesanan
{
    public string kategoriPaket;
    public int jumlahPorsii;
    public string waktu = DateTime.Now.ToShortDateString();
    public List<string> list1 = new List<string>();

    public void tambahPesanan()
    {
        list1.Add($"{kategoriPaket} | {jumlahPorsii} porsi | {waktu}");
    }

    public void cetakRiwayat()
    {
        int i= 1;
        foreach (var item in list1)
        {
            Console.WriteLine(i + ". " + item);
        }
    }

    //public RiwayatPesanan(string kategoriPaket, int jumlahPorsi, int hargaPerPorsi, int harga)
    //{

    //}
}

class Program
{
    public static void Main(string[] args)
    {
        PaketPrasmanan pesan1 = new PaketPrasmanan("Rini", "M05", "Ayam Bakar", 19000, 10);
        pesan1.tampilInfo();
        pesan1.hitungTotalBill(10);
        pesan1.riwayat.tambahPesanan();
        pesan1.riwayat.cetakRiwayat();
    }
}