using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace MyApp.Namespace
{
    public class CounterModel : PageModel
    {
        public int Count { get;set; }
        public void OnGet()
        {
            int? tempCount = HttpContext.Session.GetInt32("SessionCount");

            if (tempCount != null) {
                Count = tempCount.Value;
            }
            else {
                Count = 0;
            }
        }

        [HttpPost]
        public void OnPost(int counter)
        {
            this.Count = counter;
            HttpContext.Session.SetInt32("SessionCount", this.Count);
        }
    }
}