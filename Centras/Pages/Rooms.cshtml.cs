
using Centras.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Centras.Pages
{
    public class RoomsModel : PageModel
    {
        public Dictionary<string, List<string>> RoomImages { get; set; } = new();
        [BindProperty]
        public User User { get; set; }
        public String? ErrorMessage { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach(var key in ModelState.Keys)
                {
                    if (ModelState[key]?.Errors.Count > 0)
                    {
                        Console.WriteLine("The validation failed for:"+key);
                    }
                }
                return Page();
            }
            return Page();
        }

        public void OnGet()
        {
            RoomImages["Room 5"] = new List<string>
            {
                "Images/Room 5/Room5_1.jfif", "Images/Room 5/Room5.jfif", "Images/Room 5/Room5_2.jfif",
                "Images/Room 5/Room5_3.jfif", "Images/Room 5/Room5_4.jfif", "Images/Room 5/Room5_5.jfif"
            };

            RoomImages["Room 6"] = new List<string>
            {
                "Images/Room 6/Room6_1.jfif", "Images/Room 6/Room6_2.jfif", "Images/Room 6/Room6_3.jfif",
                "Images/Room 6/Room6_4.jfif", "Images/Room 6/Room6_5.jfif", "Images/Room 6/Room6_9.jfif",
                "Images/Room 6/Room6_6.jfif", "Images/Room 6/Room6_7.jfif", "Images/Room 6/Room6_8.jfif"
            };

            RoomImages["Room 7"] = new List<string>
            {
                "Images/Room 7/Room7_1.jfif", "Images/Room 7/Room7.jfif", "Images/Room 7/Room7_2.jfif",
                "Images/Room 7/Room7_3.jfif", "Images/Room 7/Room7_5.jfif", "Images/Room 7/Room7_6.jfif"
            };
           
            RoomImages["Room 8"] = new List<string>
            {
                "Images/Room 8/Room8_1.jfif", "Images/Room 8/Room8.jpg", "Images/Room 8/Room8_2.jfif",
                "Images/Room 8/Room8_3.jfif", "Images/Room 8/Room8_4.jfif"
            };

            RoomImages["Room 9"] = new List<string>
            {
                "Images/Room 9/Room9_1.jfif", "Images/Room 9/Room9_2.jfif", "Images/Room 9/Room9_3.jfif",
                "Images/Room 9/Room9_4.jfif", "Images/Room 9/Room9_5.jfif", "Images/Room 9/Room9_6.jfif",
                "Images/Room 9/Room9_7.jfif", "Images/Room 9/Room9_8.jfif", "Images/Room 9/Room9_9.jfif",
                "Images/Room 9/Room9_10.jfif"
            };

        }
    }
}