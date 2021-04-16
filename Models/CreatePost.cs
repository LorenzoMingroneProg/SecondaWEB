using System;
using Microsoft.AspNetCore.Http;

namespace Mingrone.Lorenzo._5h.SecondaWeb.Models
{
   public class CreatePost
  {
      public IFormFile MyCSV {get;set;}
   public string Descrizione {get;set;}

  }

}