using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        public const string Select = "<select>" +
                              "<option>--Select--</option>" +
                              "<option>Proficient</option>" +
                              "<option>Novice</option>" +
                              "<option>In Training</option>" +
                           "</select>";

        public IActionResult Index()
        {
            string html = "<h1>Skills Tracker</h1>" +
                            "<h2>Languages</h2>" +
                                "<ol>" +
                                    "<li>C#</li>" +

                                    "<li>Java</li>" +

                                    "<li>C++</li>" +
                                "</ol>";

            return Content(html, "text/html");
        }

        [HttpGet("/skills/form")]
        public IActionResult Form()
        {
            string html = $"<form action='/skills/form' method='post'>" +
                            "<input required type='date' name='dateOfTraining'></input>" +
                                SelectBox("cs", "C#") +
                                SelectBox("java", "Java") +
                                SelectBox("cpp", "C++") +                               
                            "<input type='submit'/>" +
                          "</form>";

            return Content(html, "text/html");                            
        }

        [HttpPost("/skills/form")]
        public IActionResult OnSubmit(string dateOfTraining, string cs, string java, string cpp)
        {
            //string html = $"<h1>{dateOfTraining}</h1>" +
            //                 $"<ol>" +
            //                    $"<li>C#: {cs}</li>" +
            //                    $"<li>Java: {java}</li>" +
            //                    $"<li>C++: {cpp}</li>" +
            //                  "</ol>";                

            string html = $"<h1>{dateOfTraining}</h1>" +
                 $"<table>" +
                    "<tr>" +
                       "<th>C#</th>" +
                       "<th>Java</th>" +
                       "<th>C++</th>" +
                     "</tr>" +
                     "<tr>" +
                        $"<td>{cs}</td>" +
                        $"<td>{java}</td>" +
                        $"<td>{cpp}</td>" +
                     "</tr>" +
                  "</table>";

            return Content(html, "text/html");
        }

        private string SelectBox(string name, string label)
        {
            return $"<label>{label}" +
                        $"<select name='{name}'>" +
                            "<option>--Select--</option>" +
                            "<option value='proficient'>Proficient</option>" +
                            "<option value='novice'>Novice</option>" +
                            "<option value='inTraining'>In Training</option>" +
                        "</select>" +
                    "</label>";
        }
    }
}
