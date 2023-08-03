namespace voting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> filmler = new Dictionary<string, int>()
            {
                { "nausicaa",0 },
                { "bambi",0 },
                { "harry potter",0},
                { "yürüyen şato",0 },
                { "star wars",0}
            };
            Dictionary<string, int> tech = new Dictionary<string, int>()
            {
                { "python",0 },
                { "c",0 },
                { "java",0 },
                { "c#",0}
            };
            Dictionary<string, int> spor = new Dictionary<string, int>()
            {
                { "masa tenisi",0 },
                { "basketbol",0 },
                { "voleybol",0 },
                { "tenis",0 }
            };

            List<Dictionary<string,int>> kategori = new List<Dictionary<string, int>>()
            {
                filmler,
                tech,
                spor
            };

            List<kullanici> kullanicilar = new List<kullanici>();
            int sayac = -1;
            

            while (true)
            {
                if (sayac == -1)
                {
                    Console.WriteLine("MERHABA");
                    Console.Write("kullanıcı adı(çıkış=q):");
                    string username = Console.ReadLine();
                    
                    if (username == "q")
                    {
                        break;
                    }

                    foreach (var temp in kullanicilar)
                    {
                        if (temp.isim == username)
                        {
                            sayac = 0;
                        }  
                    }
                    if (sayac == -1)
                    {
                        sayac = 1;
                    }
                    Console.WriteLine();
                }

                if (sayac == 1)
                {
                    Console.WriteLine("önce kayıt olmalısınız.");
                    Console.Write("kullanıcı adı:");
                    string Yusername = Console.ReadLine();
                    Console.Write("parola:");
                    string Yparola = Console.ReadLine();
                    kullanicilar.Add(new kullanici(Yusername, Yparola));
                    sayac = 0;
                    Console.WriteLine();
                }
                if (sayac == 0)
                {
                    Console.WriteLine("oylamaya başlamak için kategorı seçmelisiniz.");
                    Console.WriteLine("1-film\n2-programlama dilleri\n3-sporlar");
                    Console.Write("seçim:");
                    string secim = Console.ReadLine();
                    Console.WriteLine();
                    if (secim == "1")
                    {
                        foreach (var item in filmler)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.Write("oylamak istediğiniz aday:");
                        string secimf = Console.ReadLine().ToLower();

                        try
                        {
                            filmler[secimf] += 1;
                            sayac = 2;
                        }
                        catch (System.Collections.Generic.KeyNotFoundException)
                        {
                            Console.WriteLine("hatalı giriş\n");
                            sayac = 0;  
                        }


                    }
                    if (secim == "2")
                    {
                        foreach (var item in tech)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.Write("oylamak istediğiniz aday:");
                        string secimt = Console.ReadLine().ToLower();

                        try
                        {
                            tech[secimt] += 1;
                            sayac = 2;
                        }
                        catch (System.Collections.Generic.KeyNotFoundException)
                        {
                            Console.WriteLine("hatalı giriş");
                            sayac = 0;
                        }
                    }
                    if (secim == "3")
                    {
                        foreach (var item in spor)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.Write("oylamak istediğiniz aday:");
                        string secims = Console.ReadLine().ToLower();

                        try
                        {
                            spor[secims] += 1;
                            sayac = 2;
                        }
                        catch (System.Collections.Generic.KeyNotFoundException)
                        {
                            Console.WriteLine("hatalı giriş");
                            sayac = 0;
                        }

                    }
                    if (sayac == 2)
                    {
                        Console.Write("diğer kategorilerde oylamaya devam etmek ister misiniz(y/n):");
                        string secimYesNo = Console.ReadLine().ToLower();
                        if (secimYesNo == "y")
                        {
                            sayac = 0;
                        }
                        if (secimYesNo == "n")
                        {
                            int fToplam = 0;
                            int tToplam = 0;
                            int sToplam = 0;
                            
                            foreach (var item in filmler)
                            {
                                fToplam = item.Value + fToplam;
                                Console.WriteLine(fToplam);
                            }
                         Console.WriteLine("film kategorisi\n******************************");
                            foreach (var item in filmler)
                            {
                                if (fToplam == 0)
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, 0);
                                }
                                else
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, (int)((item.Value * 100) / (double)fToplam));
                                }
                            }
                            Console.WriteLine();
                            foreach (var item in tech)
                            {
                                tToplam = item.Value + tToplam;
                            }
                            Console.WriteLine("programlama dilleri kategorisi\n******************************");
                            foreach (var item in tech)
                            {

                                if (tToplam == 0)
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, 0);
                                }
                                else
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, (int)((item.Value * 100) / (double)tToplam));
                                }
                            }
                            Console.WriteLine();
                            foreach (var item in spor)
                            {
                                sToplam = item.Value + sToplam;
                            }
                            Console.WriteLine("spor kategorisi\n******************************");
                            foreach (var item in spor)
                            {

                                if (sToplam == 0)
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, 0);
                                }
                                else
                                {
                                    Console.WriteLine("{0}:  {1}  %{2}", item.Key, item.Value, (int)((item.Value * 100) / (double)sToplam));
                                }
                            }
                            Console.WriteLine();
                            sayac = -1;
                        }
                    }
                    
                }
            }
            
        }
    }
    class kullanici
    {
        private string Isim;
        private string Parola;
        public kullanici(string isimm,string parolaa)
        {
            Isim = isimm;
            Parola = parolaa;
        }
        public String isim
        {
            get { return Isim; }

            set { Isim = value; }
        }
        public String parola
        {
            get { return Parola; }

            set { Parola = value; }
        }
    }
}
