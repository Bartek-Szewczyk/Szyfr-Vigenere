using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szyfr_Vigenere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static char[] letter = new char[] { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };
        static string output;
        static char[] input;
        static int res;


        public static int getKey(string key)
        {
            int r = 0;
            input = key.ToLower().ToCharArray();

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        r = i;
                    }
                }
            }

            return r;
        }

        public static string Encryption(string plain_text, int key)
        {
            input = plain_text.ToLower().ToCharArray();

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        input[j] = letter[(i + key) % letter.Length];
                        break;
                    }
                }
            }
            output= new string(input);
            return output;
        }

        public static string Decryption(string cipher_text, int key)
        {
            input = cipher_text.ToLower().ToCharArray();

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        res = (i - key + letter.Length);
                        input[j] = letter[res % letter.Length];
                        break;
                    }
                }
            }
            output = new string(input);
            return output;
        }

        string m;
        string k;


        public void wykonaj_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBox.Text=="Szyfrowanie")
            {
                m = txt1.Text.Replace(" ", "");
                k = txtkey.Text;
                int r = 0;
                string s =null;
                for (int i = 0; i < m.Length; i++)
                {
                    if (r==k.Length-1)
                    {
                        r = 0;
                    }
                    else if (r<k.Length && i>0)
                    {
                        r++;
                    }
                    else if (r<k.Length && i == 0)
                    {
                        r = 0;
                    }

                    if (r<k.Length)
                    {
                        s+= Encryption(m.Substring(i,1).ToLower(), getKey(k.Substring(r,1).ToLower()));
                    }
                }

                txt2.Text = s;

            }
            else
            {
                m = txt1.Text.Replace(" ", "");
                k = txtkey.Text;
                int r = 0;
                string s = null;
                for (int i = 0; i < m.Length; i++)
                {
                    if (r == k.Length - 1)
                    {
                        r = 0;
                    }
                    else if (r < k.Length && i > 0)
                    {
                        r++;
                    }
                    else if (r < k.Length && i == 0)
                    {
                        r = 0;
                    }

                    if (r < k.Length)
                    {
                        s += Decryption(m.Substring(i, 1).ToLower(), getKey(k.Substring(r, 1).ToLower()));
                    }
                }

                txt2.Text = s;
                
            }

        }

        private void Clean()
        {

            txt1.Text = "Wprowadz Tekst";
            txt2.Text = "";
            txtkey.Text = "";
            Encrypted.IsSelected = true;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Clean();
        }
    }




}
