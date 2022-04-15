using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static labwork3.DataProvider;

namespace labwork3
{
    public partial class Task1 : System.Web.UI.Page
    {
        public class Task1Result
        {
            public string surname { get; set; }

            public int number_of_room { get; set; }

            public int floor { get; set; }

            public string daily_fee { get; set; }
        }

        public Dictionary<string, Task1Result> Task1Results { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Task1"] == null)
                {
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    Task1Results = new Dictionary<string, Task1Result>();

                    foreach (var client in ClientsList)
                    {

                        if (client.check_out_date == "didn`t move out")
                        {
                            Task1Results.Add(client.surname, new Task1Result
                            {
                                surname = client.surname,
                                number_of_room = client.number_of_room,
                                floor = Rooms[client.number_of_room].floor,
                                daily_fee = Rooms[client.number_of_room].daily_fee
                            });
                        }

                        else
                        {
                            continue;
                        }
                    }
                    Task1_GridView.DataSource = Task1Results.Values.OrderBy(s => s.surname).Select(res => new
                    {
                        Прізвище = res.surname,
                        Номер_Кімнати = res.number_of_room,
                        Поверх = res.floor,
                        Щоденна_Платня = res.daily_fee
                    });
                    Task1_GridView.DataBind();
                    Session["Task1"] = null;
                }
            }
        }
    }
}