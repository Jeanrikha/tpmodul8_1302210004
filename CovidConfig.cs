using System;
using System.IO;


namespace tpmodul8_1302210004
{
    internal class CovidConfig
    {
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDeman { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public void UbahSatuan()
        {
            // Mengubah satuan suhu dari celcius ke fahrenheit atau sebaliknya
            if (SatuanSuhu.ToLower() == "celcius")
            {
                SatuanSuhu = "fahrenheit";
            }
        }
    }
}
