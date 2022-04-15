using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static labwork3.DataProvider;

namespace labwork3
{ /*
                                        Варіант 59    
    Файл «Готель» має наступну структуру: номер кімнати, поверх, кількість місць у кімнаті, вартість
    проживання за одну добу. У файлі «Жильці» містяться прізвища жильців, номери кімнати, дати
    поселення та виселення. Розв’язати наступні задачі:
    a) Вивести прізвища, вартість, поверх та номер кімнати тих жильців, які ще не виселилися.
    b) Вивести номери кімнат та кількість вільних місць у них.
 */
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["logined"]!=null)
                {
                    ReadData();
                    Hotel_GridView.DataSource = Rooms.Values.OrderBy(v => v.number_of_room).Select(r => new
                    {
                        Номер_Кімнати = r.number_of_room,
                        Поверх = r.floor,
                        Місць_у_кімнаті = r.spots_in_room,
                        Щоденна_плата = r.daily_fee
                    });
                    Hotel_GridView.DataBind();
                    Clients_GridView.DataSource = Clients.Values.OrderBy(s => s.surname).Select(c => new
                    {
                        Прізвище = c.surname,
                        Номер_Кімнати = c.number_of_room,
                        Дата_Реєстрації = c.check_in_date,
                        Дата_Виселення = c.check_out_date
                    });
                    Clients_GridView.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void Task2Button_Click(object sender, EventArgs e)
        {
            Session["Task2"] = true;
            Response.Redirect("Task2.aspx");
        }

        protected void Task1Button_Click(object sender, EventArgs e)
        {
            Session["Task1"] = true;
            Response.Redirect("Task1.aspx");
        }

    }
}