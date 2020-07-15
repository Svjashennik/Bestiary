using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class zap : Form
    {

        Dictionary<string, int> aligment = new Dictionary<string, int>
        {
            {"ЗД",1 },
            {"НД",2 },
            {"ХД",3 },
            {"ЗН",4 },
            {"НН",5 },
            {"ХН",6 },
            {"ЗЗ",7 },
            {"НЗ",8 },
            {"ХЗ",9 },
            {"БМ",10 }
        };
        Dictionary<string, int> types = new Dictionary<string, int>
        {
            {"Гуманоид",1 },
            {"Зверь",2 },
            {"Дракон",3 },
            {"Монстр",4 },
            {"Абберация",5 },
            {"Нежить",6 },
            {"Великан",7 },
            {"Растение",8 },
            {"Слизь",9 },
            {"Небожитель",10 },
            {"Конструкт",11},
            {"Элементаль",12 },
            {"Исчадие",13 },
            {"Фея",14 }
        };
        Dictionary<string, int> sizes = new Dictionary<string, int>
        {
            {"Крохотный",1 },
            {"Маленький",2 },
            {"Средний",3 },
            {"Большой",4 },
            {"Огромный",5 },
            {"Громадный",6 },
            {"Средний рой крохотных",7 }
        };
        Dictionary<string, int> danger = new Dictionary<string, int>
        {
            { "0", 1 },
            {"1/8",2 },
            {"1/4",3},
            {"1/2",4},
            {"1",5},
            {"2",6},
            {"3",7},
            {"4",8},
            {"5",9},
            {"6",10},
            {"7",11},
            {"8",12},
            {"9",13},
            {"10",14},
            {"11",15},
            {"12",16},
            {"13",17},
            {"14",18},
            {"15",19},
            {"16",20},
            {"17",21},
            {"18",22},
            {"19",23},
            {"20",24},
            {"21",25},
            {"22",26},
            {"23",27},
            {"24",28},
            {"30",29}
        };
        Dictionary<string, int> books = new Dictionary<string, int>
        {
            {"Players Handbook",1 },
            {"Monster Manual",2 },
            {"Nikita Guide",3 },
        };

        public zap()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("creature.txt", true, System.Text.Encoding.Default))
            {
                foreach(TextBox tex in groupBox1.Controls)
                {
                    if (tex.Text == "")
                        tex.Text = "null";
                }
                if (namebox.Text != "null") namebox.Text = "'" + namebox.Text + "'";
                if (sense.Text != "null") sense.Text = "'" + sense.Text + "'";
                if (abilki.Text != "null") abilki.Text = "'" + abilki.Text + "'";
                if (action.Text != "null") action.Text = "'" + action.Text + "'";
                if (desc.Text != "null") desc.Text = "'" + desc.Text + "'";

                sw.WriteLine($"INSERT INTO a_bestiary VALUES(A_BESTIARY_CREATURE_ID_SEQ.nextval, {namebox.Text}, " +
                    $"{KD.Text}, {aligment[mir.Text]}, {types[type.Text]}, {sizes[size.Text]}, {HP.Text}, {danger[dang.Text]}," +
                    $"{moveGr.Text},{moveAi.Text},{moveWa.Text},{moveCl.Text},{sense.Text}," +
                    $"{sil.Text},{lov.Text},{tel.Text},{inte.Text},{mud.Text},{xar.Text}," +
                    $"{abilki.Text}, {action.Text},{desc.Text},{books[book.Text]});");
                MessageBox.Show("Добавлено.", "гатова", MessageBoxButtons.OK, MessageBoxIcon.Information);
                namebox.Text = "";
                sense.Text = "";
                abilki.Text = "";
                action.Text = "";
                desc.Text = "";
            }
        }

        private void Заполнение_Load(object sender, EventArgs e)
        {
            book.DataSource = books.Keys.ToList();
            mir.DataSource = aligment.Keys.ToList();
            dang.DataSource = danger.Keys.ToList();
            type.DataSource = types.Keys.ToList();
            size.DataSource = sizes.Keys.ToList();
        }
    }
}
