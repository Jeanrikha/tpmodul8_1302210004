using System.Text.Json;
using tpmodul8_1302210004;
class Program
{

    static void Main(string[] args)
    {

        // Membaca konfigurasi dari file
        CovidConfig config = LoadConfig();
        //MEMANGGIL METHOD UBAHSATUAN
        config.UbahSatuan();

        // meminta inputan suhu badan dan lama gejala demam
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");

        float suhu = float.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDeman = int.Parse(Console.ReadLine());
        

        // Menentukan apakah diperbolehkan masuk atau tidak berdasarkan config dan input user
        if (cekSuhu(config, suhu) && lamaDemam(config, hariDeman))
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
    }

    static CovidConfig LoadConfig()
    {
        string configFilePath = "covid_config.json";
        CovidConfig config;

        if (File.Exists(configFilePath))
        {
            // Membaca file config jika sudah ada
            string json = File.ReadAllText(configFilePath);
            config = JsonSerializer.Deserialize<CovidConfig>(json);
        }
        else
        {
            // Menggunakan nilai default jika file config belum ada
            config = new CovidConfig();
        }

        return config;
    }

    static bool cekSuhu(CovidConfig config, float suhu)
    {
        // Konversi suhu ke celcius jika inputan suhu adalah fahrenheit
        if (config.SatuanSuhu.ToLower() == "fahrenheit")
        {
            suhu = (suhu - 32) * 5 / 9;
        }

        // Periksa apakah suhu berada dalam range yang telah ditentukan 
        if (suhu >= 36.5 && suhu <= 37.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool lamaDemam(CovidConfig config, int hariDeman)
    {
        // Periksa apakah jumlah hari deman kurang dari data CONFIG2
        if (hariDeman < config.BatasHariDeman)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
