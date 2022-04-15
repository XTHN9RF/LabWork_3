using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static labwork3.DataProvider;

namespace labwork3
{
    public partial class Task2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Task2"] == null)
                {
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    Dictionary<int, int> free_spots_in_rooms = new Dictionary<int, int>();

                    int free_spots = 0;

                    foreach (var client in ClientsList)
                    {
                        if (free_spots_in_rooms.ContainsKey(client.number_of_room))
                        {
                            free_spots_in_rooms[client.number_of_room] += 1;
                        }
                        else
                        {
                            free_spots_in_rooms.Add(client.number_of_room, 1);
                        }
                    }

                    foreach (var room in free_spots_in_rooms.Keys.ToArray())
                    {
                        free_spots = Rooms[room].spots_in_room - free_spots_in_rooms[room];
                        free_spots_in_rooms[room] = free_spots >= 0 ? free_spots : 0;
                    }
                    Task2_GridView.DataSource = free_spots_in_rooms.OrderBy(room => room.Key).Select(result => new
                    {
                        Номер_Кімнати = result.Key,
                        Вільних_місць = result.Value
                    });
                    Task2_GridView.DataBind();
                    Session["Task2"] = null;
                }
                }

            }
        }
    }